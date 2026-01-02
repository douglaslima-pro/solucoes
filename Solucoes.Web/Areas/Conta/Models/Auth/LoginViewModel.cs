using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solucoes.Web.Areas.Conta.Models.Auth
{
    public class LoginViewModel
    {
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O {0} informado é inválido!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? Email { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? Password { get; set; }

        [DisplayName("Lembrar-me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
