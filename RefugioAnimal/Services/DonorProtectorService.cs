using AutoMapper;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Repositories;

namespace RefugioAnimal.Services
{
    public class DonorProtectorService
    {
        private readonly DonorProtectorRepository _repository;
        private readonly IMapper _mapper;

        public DonorProtectorService(DonorProtectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DonorProtectorDto>> GetAllDonorProtectorsAsync(PagedAndSortedResultRequestDto input)
        {
            var donorProtectors = await _repository.GetAllAsync();

            var filteredDonorProtectors = donorProtectors.AsQueryable();

            filteredDonorProtectors = filteredDonorProtectors
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            return _mapper.Map<List<DonorProtectorDto>>(filteredDonorProtectors.ToList());
        }

        public async Task<DonorProtectorDto?> GetDonorProtectorByIdAsync(long id)
        {
            var donorProtector = await _repository.GetByIdAsync(id);
            return donorProtector is null ? null : _mapper.Map<DonorProtectorDto>(donorProtector);
        }

        public async Task CreateDonorProtectorAsync(DonorProtectorDto dto)
        {
            var donorProtector = _mapper.Map<DonorProtector>(dto);
            await _repository.AddAsync(donorProtector);
        }

        public async Task UpdateDonorProtectorAsync(long id, DonorProtectorDto dto)
        {
            var donorProtector = await _repository.GetByIdAsync(id);

            if (donorProtector is null)
                throw new KeyNotFoundException("DonorProtector não encontrado.");

            _mapper.Map(dto, donorProtector);
            await _repository.UpdateAsync(donorProtector);
        }

        public async Task DeleteDonorProtectorAsync(long id)
        {
            if (!await _repository.AnyAsync(id))
                throw new KeyNotFoundException("DonorProtector não encontrado.");

            await _repository.DeleteAsync(id);
        }
    }
}
