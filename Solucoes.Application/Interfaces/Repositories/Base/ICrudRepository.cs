namespace Solucoes.Application.Interfaces.Repositories.Base
{
    public interface ICrudRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity>
        where TEntity : class
    {

    }
}
