using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Domain.Entities.Projetos
{
    public class ProjetoMembro
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public int UsuarioId { get; private set; }
        public int ProjetoPapelId { get; private set; }
        public DateTime EntrouEm { get; private set; }
        public bool? Ativo { get; private set; }

        // Propriedades privadas
        private readonly List<ItemBacklog> _tarefas = new();
        private readonly List<ProjetoConvite> _projetoConvites = new();

        // Relacionamentos
        public Projeto? Projeto { get; private set; }
        public ProjetoPapel? ProjetoPapel { get; private set; }
        public IReadOnlyCollection<ItemBacklog> Tarefas => _tarefas;
        public IReadOnlyCollection<ProjetoConvite> ProjetoConvites => _projetoConvites;

        protected ProjetoMembro() { }

        public ProjetoMembro(int projetoId, int usuarioId, int projetoPapelId)
        {
            ProjetoId = projetoId;
            UsuarioId = usuarioId;
            ProjetoPapelId = projetoPapelId;
            EntrouEm = DateTime.UtcNow;
        }
    }
}
