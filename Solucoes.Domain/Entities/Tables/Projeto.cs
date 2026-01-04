using Solucoes.Domain.Exceptions;

namespace Solucoes.Domain.Entities.Tables
{
    public class Projeto
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

            Nome = nome;
            Descricao = descricao;
            CriadoPorUsuarioId = criadoPorUsuarioId;
            CriadoEm = DateTime.UtcNow;

            AdicionarMembro(criadoPorUsuarioId, 1);
        }

        public void AlterarProductOwner(int membroId)
        {
            var membro = _membros.FirstOrDefault(m => m.Id == membroId && m.Ativo == true);

            if (membro == null)
            {
                throw new RecordNotFoundException("Membro do projeto não encontrado.");
            }

            if (membro.ProjetoPapelId == 1)
            {
                throw new DomainException(string.Empty, "O membro já é o Product Owner do projeto.");
            }

            var productOwner = _membros.Where(m => m.ProjetoPapelId == 1 && m.Ativo == true);

            foreach (var po in productOwner)
            {
                po.Desativar();
            }

            membro.AlterarPapel(1);
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

        public void RemoverMembro(int membroId)
        {
            var membro = _membros.FirstOrDefault(m => m.Id == membroId && m.Ativo == true);

            if (membro == null)
            {
                throw new RecordNotFoundException("Membro do projeto não encontrado.");
            }

            if (membro.ProjetoPapelId == 1)
            {
                throw new DomainException(string.Empty, "Não é possível remover o Product Owner do projeto.");
            }

            membro.Desativar();
        }

        public void AdicionarItemBacklog(ItemBacklog item)
        {
            if (item.ProjetoId != Id)
            {
                throw new DomainException(string.Empty, "O item de backlog não pertence a este projeto.");
            }

            _backlog.Add(item);
        }

        public void RemoverItemBacklog(ItemBacklog item)
        {
            if (!_backlog.Contains(item))
            {
                throw new DomainException(string.Empty, "O item de backlog não pertence a este projeto.");
            }

            _backlog.Remove(item);
        }

        public void AdicionarSprint(Sprint sprint)
        {
            if (sprint.ProjetoId != Id)
            {
                throw new DomainException(string.Empty, "A sprint não pertence a este projeto.");
            }

            if (_sprints.Any(s => s.Encerrada == false))
            {
                throw new DomainException(string.Empty, "Já existe uma sprint em andamento no projeto.");
            }

            _sprints.Add(sprint);
        }

        public void AdicionarConvite(ProjetoConvite convite)
        {
            if (convite.ProjetoPapelId == 1)
            {
                throw new DomainException(string.Empty, "Não é permitido convidar um Product Owner para o projeto.");
            }

            if (_membros.Any(m => m.UsuarioId == convite.UsuarioId && m.Ativo == true))
            {
                throw new DomainException(string.Empty, "Usuário já é membro do projeto.");
            }

            if (_convites.Any(c => c.UsuarioId == convite.UsuarioId && !c.Aceito == true))
            {
                throw new DomainException(string.Empty, "Já existe convite pendente para este usuário.");
            }

            _convites.Add(convite);
        }

        public void AceitarConvite(byte[] tokenHash)
        {
            var convite = _convites.FirstOrDefault(c => c.TokenHash == tokenHash);

            if (convite == null)
            {
                throw new RecordNotFoundException("Convite não encontrado.");
            }

            convite.Aceitar();
            AdicionarMembro(convite.UsuarioId, convite.ProjetoPapelId);
        }
    }
}
