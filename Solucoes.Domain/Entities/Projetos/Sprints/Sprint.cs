using Solucoes.Domain.Entities.Projetos;
using Solucoes.Domain.Exceptions;

namespace Solucoes.Domain.Entities.Projetos.Sprints
{
    public class Sprint
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool? Encerrada { get; private set; }
        public int CriadoPorProjetoMembroId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        // Propriedades privadas
        private readonly List<SprintBacklog> _backlog = new();

        // Relacionamentos
        public Projeto? Projeto { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }
        public IReadOnlyCollection<SprintBacklog> Backlog => _backlog;

        protected Sprint() { }

        public Sprint(int projetoId, string nome, DateTime inicio, DateTime fim, int projetoMembroId)
        {
            ProjetoId = projetoId;
            Nome = nome;
            DataInicio = inicio;
            DataFim = fim;
            CriadoPorProjetoMembroId = projetoMembroId;
            CriadoEm = DateTime.UtcNow;
        }
    }

}
