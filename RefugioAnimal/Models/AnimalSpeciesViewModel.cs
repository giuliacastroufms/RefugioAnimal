using RefugioAnimal.Models.DTOs;

namespace RefugioAnimal.Models
{
    public class AnimalSpeciesViewModel
    {
        public List<AnimalDto>? Cats { get; set; }
        public List<AnimalDto>? Dogs { get; set; }
    }
}
