using Solucoes.Domain.Enums;

namespace Solucoes.Domain.Entities.Tables
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
        public IReadOnlyCollection<ItemBacklog> Tarefas { get; private set; }
        public IReadOnlyCollection<ProjetoConvite> ProjetoConvites { get; private set; }

        protected ProjetoMembro() { }

        public ProjetoMembro(int projetoId, int usuarioId, int projetoPapelId)
        {
            ProjetoId = projetoId;
            UsuarioId = usuarioId;
            ProjetoPapelId = projetoPapelId;
            EntrouEm = DateTime.UtcNow;
        }

        public void AlterarPapel(int novoPapelId)
        {
            ProjetoPapelId = novoPapelId;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}
