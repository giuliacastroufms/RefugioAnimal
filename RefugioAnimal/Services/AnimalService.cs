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

        public async Task<List<AnimalDto>> GetAllAnimalsAsync()
        {
            var animals = await _repository.GetAllAsync();
            return _mapper.Map<List<AnimalDto>>(animals);
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

        public async Task<List<AnimalDto>> GetAnimalsBySpecieAsync(Species species, int maxItems)
        {
            var animals = await _repository.GetAllAsync();
            var filteredAnimals = animals
                .Where(a => a.Species.Equals(species) )
                .Take(maxItems)
                .ToList();

            return _mapper.Map<List<AnimalDto>>(filteredAnimals);
        }
    }
}
