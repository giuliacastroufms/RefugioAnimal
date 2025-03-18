using Microsoft.AspNetCore.Identity;
using RefugioAnimal.Models.Entities;

namespace RefugioAnimal.Models.DTOs
{
    public class UserDto : IdentityUser
    {
        public required string FullName { get; set; }
        public virtual DonorProtectorDto? DonorProtector { get; set; }
        public virtual NGO? NGO { get; set; }
    }
}
