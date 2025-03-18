namespace RefugioAnimal.Models.DTOs
{
    public class DonorProtectorDto
    {
        public long Id { get; set; }
        public required string CPF { get; set; }
        public required string Address { get; set; }

        public required string UserId { get; set; }
        public virtual UserDto? UserDto { get; set; }
    }
}
