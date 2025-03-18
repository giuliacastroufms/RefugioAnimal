using Microsoft.AspNetCore.Identity;

namespace RefugioAnimal.Models.Entities
{
    public class User : IdentityUser
    {
        public required string FullName { get; set; }
        public virtual DonorProtector? DonorProtector { get; set; }
        public virtual NGO? NGO { get; set; }
    }
}
