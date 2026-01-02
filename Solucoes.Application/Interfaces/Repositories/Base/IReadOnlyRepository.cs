using Solucoes.Domain.Entities.Pagination;
using Solucoes.Domain.Enums;
using System.Linq.Expressions;

namespace Solucoes.Application.Interfaces.Repositories.Base
{
    public interface IReadOnlyRepository<TEntity> : IRepository
        where TEntity : class
    {
        Task<TEntity?> FindByIdAsync(int id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null);
        Task<PagedResult<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null, int page = 1, int pageSize = 10);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> searchExpression);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> searchExpression);
    }
}
