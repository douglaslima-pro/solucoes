namespace Solucoes.Domain.Entities.Projetos.ItemBacklogs
{
    public class ItemBacklogAnexo
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ItemBacklogId { get; private set; }
        public string Nome { get; private set; }
        public string Url { get; private set; }
        public int CriadoPorProjetoMembroId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        // Relacionamentos
        public ItemBacklog? ItemBacklog { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }

        protected ItemBacklogAnexo() { }

        public ItemBacklogAnexo(int itemBacklogId, string nome, string url, int projetoMembroId)
        {
            ItemBacklogId = itemBacklogId;
            Nome = nome;
            Url = url;
            CriadoEm = DateTime.UtcNow;
            CriadoPorProjetoMembroId = projetoMembroId;
        }
    }
}
