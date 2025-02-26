namespace RefugioAnimal.Models.Entities
{
    public class Adoption
    {
        public long Id { get; set; } 
        public long UserId { get; set; }
        public long AnimalId { get; set; }
        public DateTime Date { get; set; }
        public required string Status { get; set; }
        public long AdoptionTypeId { get; set; }

        //public virtual User? User { get; set; }
        public virtual Animal? Animal { get; set; }
        public virtual AdoptionType? AdoptionType { get; set; }
    }
}
