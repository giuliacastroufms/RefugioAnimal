using RefugioAnimal.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RefugioAnimal.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Display(Name = "Telefone")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [PasswordComplexity]
        public required string Password { get; set; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        [Display(Name = "Tipo de usuário")]
        public required UserType UserType { get; set; }

        [MaxLength(14, ErrorMessage = "O CPF deve ter no máximo 14 caracteres.")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [Display(Name = "Endereço")]
        public required string Address { get; set; }

        [MaxLength(18, ErrorMessage = "O CNPJ deve ter no máximo 18 caracteres.")]
        public string? CNPJ { get; set; }

        [Display(Name = "Responsável")]
        public string? Responsible { get; set; }

        [Display(Name = "Telefone do responsável")]
        public string? ResponsiblePhoneNumber { get; set; }
    }

    public class PasswordComplexityAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;

            if (password == null)
            {
                return new ValidationResult("A senha é obrigatória.");
            }

            // Requer uma letra maiúscula
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("A senha deve conter pelo menos uma letra maiúscula.");
            }

            // Requer um número
            if (!Regex.IsMatch(password, @"\d"))
            {
                return new ValidationResult("A senha deve conter pelo menos um número.");
            }

            // Requer um caractere especial
            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                return new ValidationResult("A senha deve conter pelo menos um caractere especial.");
            }

            return ValidationResult.Success;
        }
    }
}
