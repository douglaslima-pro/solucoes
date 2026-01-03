using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solucoes.Web.Areas.Conta.Models.Auth
{
    public class ConfirmEmailViewModel
    {
        public bool Succeeded { get; set; }
        public string? Error { get; set; }
    }
}
