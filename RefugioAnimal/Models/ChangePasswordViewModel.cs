using System.ComponentModel.DataAnnotations;

namespace RefugioAnimal.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        [Compare("ConfirmNewPassword", ErrorMessage = "As senhas não coincidem.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        public string ConfirmNewPassword { get; set; }
    }
}
