using Microsoft.AspNetCore.Identity;

namespace RefugioAnimal.Models.Entities
{
    public class User : IdentityUser
    {
        public required string FullName { get; set; }
    }
}
