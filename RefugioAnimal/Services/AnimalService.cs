using AutoMapper;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Models.Enums;
using RefugioAnimal.Repositories;

namespace RefugioAnimal.Services
{
    public class AnimalService
    {
        private readonly AnimalRepository _repository;
        private readonly IMapper _mapper;

        public AnimalService(AnimalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AnimalDto>> GetAllAnimalsAsync(int maxItems, AdoptionStatus adoptionStatus)
        {
            var animals = await _repository.GetAllAsync();
            var filteredAnimals = animals
                .Where(a => a.AdoptionStatus.Equals(AdoptionStatus.Available))
                .Take(maxItems)
                .ToList();
            return _mapper.Map<List<AnimalDto>>(filteredAnimals);
        }

        public async Task<AnimalDto?> GetAnimalByIdAsync(long id)
        {
            var animal = await _repository.GetByIdAsync(id);
            return animal is null ? null : _mapper.Map<AnimalDto>(animal);
        }

        public async Task CreateAnimalAsync(CreateAnimalDto dto)
        {
            var animal = _mapper.Map<Animal>(dto);
            await _repository.AddAsync(animal);
        }

        public async Task UpdateAnimalAsync(long id, UpdateAnimalDto dto)
        {
            var animal = await _repository.GetByIdAsync(id);

            if (animal is null)
                throw new KeyNotFoundException("Animal não encontrado.");

            _mapper.Map(dto, animal);
            await _repository.UpdateAsync(animal);
        }

        public async Task DeleteAnimalAsync(long id)
        {
            if (!await _repository.AnyAsync(id))
                throw new KeyNotFoundException("Animal não encontrado.");

            await _repository.DeleteAsync(id);
        }

        public async Task<List<AnimalDto>> GetAnimalsBySpecieAsync(Species species, int maxItems, AdoptionStatus adoptionStatus)
        {
            var animals = await _repository.GetAllAsync();
            var filteredAnimals = animals
                .Where(a => a.Species.Equals(species) )
                .Where(a => a.AdoptionStatus.Equals(adoptionStatus))
                .Take(maxItems)
                .ToList();

            return _mapper.Map<List<AnimalDto>>(filteredAnimals);
        }

        public async Task<List<AnimalDto>> GetAdoptedAnimalsAsync(int maxItems)
        {
            var animals = await _repository.GetAllAsync();
            var filteredAnimals = animals
                .Where(a => a.AdoptionStatus.Equals(AdoptionStatus.Adopted))
                .Take(maxItems)
                .ToList();

            return _mapper.Map<List<AnimalDto>>(filteredAnimals);
        }

        public async Task<AnimalDto?> GetRandomAnimalAsync()
        {
            var animals = await _repository.GetAllAsync();
            var filteredAnimals = animals
                .Where(a => a.AdoptionStatus.Equals(AdoptionStatus.Available))
                .ToList();

            if (filteredAnimals is null || !filteredAnimals.Any())
            {
                return null;
            }

            var random = new Random();
            var randomAnimal = filteredAnimals.OrderBy(a => random.Next()).FirstOrDefault();
            return randomAnimal is null ? null : _mapper.Map<AnimalDto>(randomAnimal);
        }

    }
}
