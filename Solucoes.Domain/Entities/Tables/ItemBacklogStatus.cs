namespace Solucoes.Domain.Entities.Tables
{
    public class ItemBacklogStatus
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool? Ativo { get; private set; }

        protected ItemBacklogStatus() { }

        public ItemBacklogStatus(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public ItemBacklogStatus(int id, string codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }
    }
}
