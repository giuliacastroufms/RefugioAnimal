using System.ComponentModel.DataAnnotations;

namespace RefugioAnimal.Models
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        public required string Email { get; set; }
    }
}
