namespace Solucoes.Domain.Entities.Projetos.ItemBacklogs
{
    public class ItemBacklogHistorico
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ItemBacklogId { get; private set; }
        public int ItemBacklogStatusAnteriorId { get; private set; }
        public int ItemBacklogStatusAtualId { get; private set; }
        public int AlteradoPorProjetoMembroId { get; private set; }
        public DateTime AlteradoEm { get; private set; }

        // Relacionamentos
        public ItemBacklog? ItemBacklog { get; private set; }
        public ItemBacklogStatus? ItemBacklogStatusAnterior { get; private set; }
        public ItemBacklogStatus? ItemBacklogStatusAtual { get; private set; }
        public ProjetoMembro? AlteradoPorProjetoMembro { get; private set; }

        protected ItemBacklogHistorico() { }

        public ItemBacklogHistorico(int itemBacklogId, int itemBacklogStatusAnteriorId, int itemBacklogStatusAtualId, int projetoMembroId)
        {
            ItemBacklogId = itemBacklogId;
            ItemBacklogStatusAnteriorId = itemBacklogStatusAnteriorId;
            ItemBacklogStatusAtualId = itemBacklogStatusAtualId;
            AlteradoPorProjetoMembroId = projetoMembroId;
            AlteradoEm = DateTime.UtcNow;
        }
    }
}
