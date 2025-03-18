using AutoMapper;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Repositories;

namespace RefugioAnimal.Services
{
    public class NGOService
    {
        private readonly NGORepository _repository;
        private readonly IMapper _mapper;

        public NGOService(NGORepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<NGODto>> GetAllNGOsAsync(PagedAndSortedResultRequestDto input)
        {
            var ngos = await _repository.GetAllAsync();

            var filteredONGs = ngos.AsQueryable();

            filteredONGs = filteredONGs
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            return _mapper.Map<List<NGODto>>(filteredONGs.ToList());
        }

        public async Task<NGODto?> GetNGOByIdAsync(long id)
        {
            var ngo = await _repository.GetByIdAsync(id);
            return ngo is null ? null : _mapper.Map<NGODto>(ngo);
        }

        public async Task CreateNGOAsync(NGODto dto)
        {
            var ngo = _mapper.Map<NGO>(dto);
            await _repository.AddAsync(ngo);
        }

        public async Task UpdateDonorAsync(long id, NGODto dto)
        {
            var ngo = await _repository.GetByIdAsync(id);

            if (ngo is null)
                throw new KeyNotFoundException("ONG não encontrada.");

            _mapper.Map(dto, ngo);
            await _repository.UpdateAsync(ngo);
        }

        public async Task DeleteDonorAsync(long id)
        {
            if (!await _repository.AnyAsync(id))
                throw new KeyNotFoundException("ONG não encontrada.");

            await _repository.DeleteAsync(id);
        }
    }
}
