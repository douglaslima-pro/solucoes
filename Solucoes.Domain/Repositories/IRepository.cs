using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucoes.Domain.Entities;

namespace Solucoes.Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : AggregateRoot
    {
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
