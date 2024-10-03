using AutoMapper;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models.Common;
using Homemap.Domain.Common;

namespace Homemap.ApplicationCore.Services
{
    public abstract class BaseService<TEntity, TDto> : IService<TDto>
        where TEntity : Entity
        where TDto : EntityDto
    {
        private readonly IMapper _mapper;

        private readonly ICrudRepository<TEntity> _repository;

        public BaseService(IMapper mapper, ICrudRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            TEntity? entity = await _repository.FindByIdAsync(id);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<TDto>(entity);
        }

        public async Task<IReadOnlyList<TDto>> GetAllAsync()
        {
            IReadOnlyList<TEntity> entities = await _repository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<TDto>>(entities);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            entity = await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> UpdateAsync(int id, TDto dto)
        {
            TEntity? entity = await _repository.FindByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Entity not found", nameof(dto));
            }

            if (dto.Id != id)
            {
                throw new ArgumentException("Invalid data", nameof(dto));
            }

            entity = _mapper.Map(dto, entity);

            _repository.Update(entity);
            await _repository.SaveAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity? entity = await _repository.FindByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Entity not found", nameof(id));
            }

            _repository.Remove(entity);
            await _repository.SaveAsync();
        }
    }
}
