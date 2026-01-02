using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solucoes.Web.Areas.Conta.Models.Auth
{
    public class RegisterViewModel
    {
        [DisplayName("Primeiro nome")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? PrimeiroNome { get; set; }

        [DisplayName("Sobrenome")]
        public string? Sobrenome { get; set; }

        [DisplayName("Nome de usuário")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? UserName { get; set; }

        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O {0} informado é inválido!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? Email { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A {0} deve ter no mínimo {1} caracteres!")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "A senha deve ter pelo menos uma letra maiúscula, um número e um caractere especial.")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? Password { get; set; }

        [DisplayName("Confirmar senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais!")]
        public string? ConfirmPassword { get; set; }
    }
}
