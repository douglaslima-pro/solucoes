using Solucoes.Domain.Exceptions;

namespace Solucoes.Domain.Entities.Tables
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
        private readonly List<ItemBacklog> _itens = new();

        // Relacionamentos
        public Projeto? Projeto { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }
        public IReadOnlyCollection<ItemBacklog> Itens => _itens;

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

        public void Encerrar()
        {
            Encerrada = true;
        }

        public void AdicionarItem(ItemBacklog item)
        {
            if (item.ProjetoId != ProjetoId)
            {
                throw new DomainException(string.Empty, "O item pertence a um projeto diferente.");
            }

            if (item.SprintId != null)
            {
                throw new DomainException(string.Empty, "O item já está associado a uma sprint.");
            }

            if (item.ItemBacklogStatusId == 4)
            {
                throw new DomainException(string.Empty, "Não é possível adicionar itens concluídos à sprint.");
            }

            if (item.ItemBacklogStatusId == 5)
            {
                throw new DomainException(string.Empty, "Não é possível adicionar itens cancelados à sprint.");
            }

            _itens.Add(item);
            item.AtribuirSprint(Id);
        }
    }

}
