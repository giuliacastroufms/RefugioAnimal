namespace RefugioAnimal.Models.Entities
{
    public class DonorProtector
    {
        public long Id { get; set; }
        public required string CPF { get; set; }
        public required string Address { get; set; }

        public required string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
