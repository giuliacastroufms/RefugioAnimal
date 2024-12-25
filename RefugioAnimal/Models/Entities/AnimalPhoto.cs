namespace RefugioAnimal.Models.Entities
{
    public class AnimalPhoto
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public required string Photo { get; set; }
    }
}
