namespace RefugioAnimal.Models.DTOs
{
    public class CreateAnimalDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? BreedId { get; set; }
        public required string Specie { get; set; }
    }
}
