using RefugioAnimal.Models.Enums;

namespace RefugioAnimal.Models.Entities
{
    public class Animal
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? BreedId { get; set; }
        public string? UserId { get; set; }
        public Species Species { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }

        public virtual Breed? Breed { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<AnimalPhoto> Photos { get; set; } = new List<AnimalPhoto>();
    }
}
