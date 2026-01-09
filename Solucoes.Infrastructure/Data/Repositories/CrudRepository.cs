using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solucoes.Domain.Entities;
using Solucoes.Domain.Repositories;

namespace Solucoes.Infrastructure.Data.Repositories
{
    public class CrudRepository<TEntity, TKey, TContext> : Repository<TEntity, TContext>, ICrudRepository<TEntity, TKey>
        where TEntity : AggregateRoot
        where TKey : struct
        where TContext : DbContext
    {
        protected CrudRepository(TContext context) : base(context) { }

        public async Task AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task<TEntity?> FindByIdAsync(TKey id)
        {
            return await _entity.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

        public void UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
