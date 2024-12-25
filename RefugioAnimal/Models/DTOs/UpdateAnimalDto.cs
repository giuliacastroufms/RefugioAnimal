namespace RefugioAnimal.Models.DTOs
{
    public class UpdateAnimalDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? BreedId { get; set; }
        public required string Specie { get; set; }
        public required string AdoptionStatus { get; set; }
    }
}
