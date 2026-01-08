using Solucoes.Domain.Exceptions;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;
using Solucoes.Domain.Entities.Projetos.Sprints;

namespace Solucoes.Domain.Entities.Projetos
{
    public class Projeto : AggregateRoot
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int CriadoPorUsuarioId { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public bool? Ativo { get; private set; }

        // Propriedades privadas
        private readonly List<ProjetoMembro> _membros = new();
        private readonly List<ItemBacklog> _backlog = new();
        private readonly List<Sprint> _sprints = new();
        private readonly List<ProjetoConvite> _convites = new();

        // Relacionamentos
        public IReadOnlyCollection<ProjetoMembro> Membros => _membros;
        public IReadOnlyCollection<ItemBacklog> Backlog => _backlog;
        public IReadOnlyCollection<Sprint> Sprints => _sprints;
        public IReadOnlyCollection<ProjetoConvite> Convites => _convites;

        protected Projeto() { }

        public Projeto(string nome, string descricao, int criadoPorUsuarioId)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException(string.Empty, "Nome do projeto é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new DomainException(string.Empty, "Descrição do projeto é obrigatório.");
            }

            Nome = nome;
            Descricao = descricao;
            CriadoPorUsuarioId = criadoPorUsuarioId;
            CriadoEm = DateTime.UtcNow;

            AdicionarMembro(criadoPorUsuarioId, 1);
        }

        public void AdicionarMembro(int usuarioId, int projetoPapelId)
        {
            if (projetoPapelId == 1 && _membros.Any(m => m.ProjetoPapelId == 1 && m.Ativo == true))
            {
                throw new DomainException(string.Empty, "Já existe um Product Owner no projeto.");
            }

            if (_membros.Any(m => m.UsuarioId == usuarioId && m.Ativo == true))
            {
                throw new DomainException(string.Empty, "O usuário já é membro ativo do projeto.");
            }

            _membros.Add(new ProjetoMembro(Id, usuarioId, projetoPapelId));
        }
    }
}
