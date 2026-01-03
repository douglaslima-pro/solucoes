using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solucoes.Web.Areas.Conta.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O {0} informado é inválido!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string? Email { get; set; }
    }
}
