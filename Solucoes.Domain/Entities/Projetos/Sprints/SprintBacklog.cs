using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Domain.Entities.Projetos.Sprints
{
    public class SprintBacklog
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int SprintId { get; private set; }
        public int ItemBacklogId { get; private set; }

        // Relacionamentos
        public Sprint? Sprint { get; private set; }
        public ItemBacklog? ItemBacklog { get; private set; }

        protected SprintBacklog() { }

        public SprintBacklog(int sprintId, int itemBacklogId)
        {
            SprintId = sprintId;
            ItemBacklogId = itemBacklogId;
        }
    }
}
