using AutoMapper;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Mappings
{
    internal class ReceiverProfile : Profile
    {
        public ReceiverProfile()
        {
            CreateMap<Receiver, ReceiverDto>()
                .ReverseMap();
        }
    }
}
