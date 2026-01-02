namespace Solucoes.Domain.Entities.Pagination
{
    public class PagedResult<T>
        where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Pagination Pagination { get; set; }

        public PagedResult()
        {
            Items = new List<T>();
            Pagination = new Pagination();
        }
    }
}
