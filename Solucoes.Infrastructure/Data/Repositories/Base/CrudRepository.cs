using Microsoft.EntityFrameworkCore;
using Solucoes.Application.Interfaces.Repositories.Base;
using Solucoes.Domain.Entities.Pagination;
using Solucoes.Domain.Enums;
using System.Linq.Expressions;

namespace Solucoes.Infrastructure.Data.Repositories.Base
{
    /// <summary>
    /// Implementação da interface <see cref="ICrudRepository{TEntity}"/> utilizando Entity Framework Core
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>
    /// <typeparam name="TContext">Tipo da classe de contexto</typeparam>
    public abstract class CrudRepository<TEntity, TContext> : Repository<TEntity, TContext>, ICrudRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected CrudRepository(TContext context) : base(context) { }

        public async Task AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> searchExpression)
        {
            return await _entity.CountAsync(searchExpression);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> searchExpression)
        {
            return await _entity.AnyAsync(searchExpression);
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null)
        {
            var query = _entity.AsQueryable();

            if (searchExpression != null)
            {
                query = query.Where(searchExpression);
            }

            if (orderByExpression != null)
            {
                if (orderByDirection == OrderByDirection.Ascending)
                {
                    query = query.OrderBy(orderByExpression);
                }
                else
                {
                    query = query.OrderByDescending(orderByExpression);
                }
            }

            if (includeExpression != null)
            {
                foreach (var include in includeExpression)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null)
        {
            var query = _entity.AsQueryable();

            if (searchExpression != null)
            {
                query = query.Where(searchExpression);
            }

            if (orderByExpression != null)
            {
                if (orderByDirection == OrderByDirection.Ascending)
                {
                    query = query.OrderBy(orderByExpression);
                }
                else
                {
                    query = query.OrderByDescending(orderByExpression);
                }
            }

            if (includeExpression != null)
            {
                foreach (var include in includeExpression)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<PagedResult<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>>? searchExpression = null, Expression<Func<TEntity, object>>? orderByExpression = null, OrderByDirection orderByDirection = OrderByDirection.Ascending, Expression<Func<TEntity, object>>[]? includeExpression = null, int page = 1, int pageSize = 10)
        {
            var query = _entity.AsQueryable();

            if (searchExpression != null)
            {
                query = query.Where(searchExpression);
            }

            var count = await query.CountAsync();

            if (orderByExpression != null)
            {
                if (orderByDirection == OrderByDirection.Ascending)
                {
                    query = query.OrderBy(orderByExpression);
                }
                else
                {
                    query = query.OrderByDescending(orderByExpression);
                }
            }

            if (includeExpression != null)
            {
                foreach (var include in includeExpression)
                {
                    query = query.Include(include);
                }
            }

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TEntity>
            {
                Items = items,
                Pagination = new Pagination
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)count / pageSize),
                    TotalItems = count
                }
            };
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entity.UpdateRange(entities);
        }
    }
}
