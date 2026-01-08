namespace Solucoes.Web.Areas.Projetos.Models.Home
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? CriadoPorUsuarioNome { get; set; }
        public DateTime? CriadoEm { get; set; }
        public int QuantidadeMembros { get; set; }
    }
}
