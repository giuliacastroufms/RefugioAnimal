using RefugioAnimal.Models.DTOs;

namespace RefugioAnimal.Models
{
    public class AnimalViewModel
    {
        public List<AnimalDto>? Cats { get; set; }
        public List<AnimalDto>? Dogs { get; set; }
        public List<AnimalDto>? AdoptedAnimals { get; set; }
        public AnimalDto? RandomAnimal { get; set; }
        public List<AnimalDto>? Animals { get; set; }
    }
}
