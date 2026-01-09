using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucoes.Domain.Entities;

namespace Solucoes.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : AggregateRoot
        where TKey : struct
    {
        Task<TEntity?> FindByIdAsync(TKey id);
    }
}
