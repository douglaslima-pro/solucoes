namespace Solucoes.Domain.Entities.Projetos.ItemBacklogs
{
    public class ItemBacklogComentario
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ItemBacklogId { get; private set; }
        public string? Texto { get; private set; }
        public int CriadoPorProjetoMembroId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        // Relacionamentos
        public ItemBacklog? ItemBacklog { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }

        protected ItemBacklogComentario() { }

        public ItemBacklogComentario(int itemBacklogId, string texto, int projetoMembroId)
        {
            ItemBacklogId = itemBacklogId;
            Texto = texto;
            CriadoPorProjetoMembroId = projetoMembroId;
            CriadoEm = DateTime.UtcNow;
        }
    }
}
