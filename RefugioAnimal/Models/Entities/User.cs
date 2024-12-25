using RefugioAnimal.Models.Enums;

namespace RefugioAnimal.Models.Entities
{
    public class User
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string CPF { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Role Role { get; set; }
    }
}
