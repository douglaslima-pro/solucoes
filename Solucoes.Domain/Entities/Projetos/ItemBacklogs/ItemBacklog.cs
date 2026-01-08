using Solucoes.Domain.Entities.Projetos.Sprints;

namespace Solucoes.Domain.Entities.Projetos.ItemBacklogs
{
    public class ItemBacklog
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int ItemBacklogTipoId { get; private set; }
        public int ItemBacklogStatusId { get; private set; }
        public int CriadoPorProjetoMembroId { get; private set; }
        public int? ResponsavelProjetoMembroId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        // Propriedades privadas
        private readonly List<SprintBacklog> _sprints = new();
        private readonly List<ItemBacklogComentario> _comentarios = new();
        private readonly List<ItemBacklogAnexo> _anexos = new();
        private readonly List<ItemBacklogHistorico> _historico = new();

        // Relacionamentos
        public IReadOnlyCollection<SprintBacklog> Sprints => _sprints;
        public IReadOnlyCollection<ItemBacklogComentario> Comentarios => _comentarios;
        public IReadOnlyCollection<ItemBacklogAnexo> Anexos => _anexos;
        public IReadOnlyCollection<ItemBacklogHistorico> Historico => _historico;
        public Projeto? Projeto { get; private set; }
        public ItemBacklogTipo? ItemBacklogTipo { get; private set; }
        public ItemBacklogStatus? ItemBacklogStatus { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }
        public ProjetoMembro? ResponsavelProjetoMembro { get; private set; }

        protected ItemBacklog() { }

        public ItemBacklog(int projetoId, string titulo, string descricao, int itemBacklogTipoId, int projetoMembroId)
        {
            ProjetoId = projetoId;
            Titulo = titulo;
            Descricao = descricao;
            ItemBacklogTipoId = itemBacklogTipoId;
            ItemBacklogStatusId = 1;
            CriadoPorProjetoMembroId = projetoMembroId;
            CriadoEm = DateTime.UtcNow;
        }
    }
}
