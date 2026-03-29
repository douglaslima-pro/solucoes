using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solucoes.Domain.Entities;
using Solucoes.Domain.Repositories.Base;

namespace Solucoes.Infrastructure.Data.Repositories.Base
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

        public async Task<bool> RemoveAsync(TKey id)
        {
            var entity = await _entity.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _entity.Remove(entity);
            return true;
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
