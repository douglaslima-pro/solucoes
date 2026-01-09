using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solucoes.Web.Areas.Projetos.Models.Home
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório")]
        [MinLength(3, ErrorMessage = "{0} deve ter no mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string? Nome { get; set; }
        [DisplayName("Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório")]
        [MinLength(10, ErrorMessage = "{0} deve ter no mínimo {1} caracteres")]
        [MaxLength(500, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string? Descricao { get; set; }
        public string? CriadoPorUsuarioNome { get; set; }
        public DateTime? CriadoEm { get; set; }
        public int QuantidadeMembros { get; set; }
    }
}
