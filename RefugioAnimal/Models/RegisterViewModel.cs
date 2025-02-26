using System.ComponentModel.DataAnnotations;

namespace RefugioAnimal.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "As senhas não coincidem.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        public required string ConfirmPassword { get; set; }
    }
}
