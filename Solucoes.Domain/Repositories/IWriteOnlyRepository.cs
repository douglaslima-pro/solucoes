using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucoes.Domain.Entities;

namespace Solucoes.Domain.Repositories
{
    public interface IWriteOnlyRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : AggregateRoot
        where TKey : struct
    {
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
