namespace RefugioAnimal.Models.DTOs
{
    public class AdoptionDto
    {
        public long Id { get; set; }
        public required string UserId { get; set; }
        public long AnimalId { get; set; }
        public DateTime Date { get; set; }
        public required string Status { get; set; }
        public long AdoptionTypeId { get; set; }
        public virtual UserDto? UserDto { get; set; }
        public virtual AnimalDto? AnimalDto { get; set; }
        public virtual AdoptionTypeDto? AdoptionTypeDto { get; set; }
    }
}
