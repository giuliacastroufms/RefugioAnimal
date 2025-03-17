namespace RefugioAnimal.Models.Entities
{
    public class NGO
    {
        public long Id { get; set; }
        public required string CNPJ { get; set; }
        public required string Address { get; set; }
        public string? Responsible { get; set; }
        public string? ResponsiblePhoneNumber { get; set; }

        public required string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
