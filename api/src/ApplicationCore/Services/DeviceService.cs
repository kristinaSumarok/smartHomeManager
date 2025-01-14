﻿using AutoMapper;
using ErrorOr;
using Homemap.ApplicationCore.Errors;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Models.Messaging;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Services
{
    public class DeviceService : BaseService<Device, DeviceDto>, IDeviceService
    {
        private readonly IMapper _mapper;

        private readonly IDeviceRepository _deviceRepository;

        private readonly ICrudRepository<Receiver> _receiverRepository;

        private readonly IMessagingService<DeviceStateDto> _messagingService;

        public DeviceService(
            IMapper mapper,
            IDeviceRepository deviceRepository,
            ICrudRepository<Receiver> receiverRepository,
            IMessagingService<DeviceStateDto> messagingService
        ) : base(mapper, deviceRepository)
        {
            _deviceRepository = deviceRepository;
            _receiverRepository = receiverRepository;
            _mapper = mapper;
            _messagingService = messagingService;
        }

        public async Task<ErrorOr<IReadOnlyList<DeviceDto>>> GetAllAsync(int receiverId)
        {
            Receiver? receiver = await _receiverRepository.FindByIdAsync(receiverId);

            if (receiver == null)
            {
                return UserErrors.EntityNotFound($"Receiver was not found ('{receiverId}')");
            }

            IReadOnlyList<Device> devices = await _deviceRepository.FindAllByReceiverId(receiverId);
            return _mapper.Map<IReadOnlyList<DeviceDto>>(devices).ToErrorOr();
        }

        public async Task<ErrorOr<DeviceDto>> CreateAsync(int receiverId, DeviceDto dto)
        {
            Receiver? receiver = await _receiverRepository.FindByIdAsync(receiverId);

            if (receiver == null)
            {
                return UserErrors.EntityNotFound($"Receiver was not found ('{receiverId}')");
            }

            Device deviceEntity = _mapper.Map<Device>(dto);
            deviceEntity.Receiver = receiver;

            await _deviceRepository.AddAsync(deviceEntity);
            await _deviceRepository.SaveAsync();

            return _mapper.Map<DeviceDto>(deviceEntity);
        }

        public async Task<ErrorOr<Updated>> SetStateAsync(int deviceId, DeviceStateDto deviceStateDto)
        {
            Device? device = await _deviceRepository.FindByIdAsync(deviceId);

            if (device is null)
                return UserErrors.EntityNotFound($"Device was not found ('{deviceId}')");

            // TODO: perform validation that state can be used for this device
            //  must be performed on domain level as it is domain specific logic

            await _messagingService.PublishAsync(
                $"devices/{deviceId}/set-state",
                deviceStateDto,
                new MessagingServicePublishOptions
                {
                    QualityOfService = MessagingQualityOfService.EXACTLT_ONCE
                }
            );

            return Result.Updated;
        }

        public async Task<ErrorOr<DeviceStateDto>> GetStateAsync(int deviceId)
        {
            Device? device = await _deviceRepository.FindByIdAsync(deviceId);

            if (device is null)
                return UserErrors.EntityNotFound($"Device was not found ('{deviceId}')");

            // assume that device has published the initial state message
            await _messagingService.SubscribeAsync($"devices/{deviceId}/state");

            var tcs = new TaskCompletionSource<DeviceStateDto>();

            while (true)
            {
                if (_messagingService.ReceivedMessages.TryDequeue(out var deviceState))
                {
                    if (deviceState is not null)
                    {
                        // TODO: validate device state from broker as well

                        tcs.SetResult(deviceState);
                        break;
                    }
                }
            }

            return await tcs.Task;
        }
    }
}
