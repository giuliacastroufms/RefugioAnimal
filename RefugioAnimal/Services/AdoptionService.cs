using AutoMapper;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Repositories;

namespace RefugioAnimal.Services
{
    public class AdoptionService
    {
        private readonly AdoptionRepository _repository;
        private readonly IMapper _mapper;

        public AdoptionService(AdoptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AdoptionDto>> GetAllAdoptionsAsync(PagedAndSortedResultRequestDto input)
        {
            var adoptions = await _repository.GetAllAsync();

            var filteredAdoptions = adoptions.AsQueryable();

            filteredAdoptions = filteredAdoptions
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            return _mapper.Map<List<AdoptionDto>>(filteredAdoptions.ToList());
        }

        public async Task<AdoptionDto?> GetAdoptionByIdAsync(long id)
        {
            var adoption = await _repository.GetByIdAsync(id);
            return adoption is null ? null : _mapper.Map<AdoptionDto>(adoption);
        }

        public async Task CreateAdoptionAsync(AdoptionDto dto)
        {
            var adoption = _mapper.Map<Adoption>(dto);
            await _repository.AddAsync(adoption);
        }

        public async Task UpdateAdoptionAsync(long id, AdoptionDto dto)
        {
            var adoption = await _repository.GetByIdAsync(id);

            if (adoption is null)
                throw new KeyNotFoundException("Adoção não encontrada.");

            _mapper.Map(dto, adoption);
            await _repository.UpdateAsync(adoption);
        }

        public async Task DeleteAdoptionAsync(long id)
        {
            if (!await _repository.AnyAsync(id))
                throw new KeyNotFoundException("Adoção não encontrada.");

            await _repository.DeleteAsync(id);
        }
    }
}
