namespace RefugioAnimal.Models.DTOs
{
    public class AnimalDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? BreedDescription { get; set; }
        public required string Specie { get; set; }
        public required string AdoptionStatus { get; set; }
        public List<string> Photos { get; set; } = new();
    }
}
