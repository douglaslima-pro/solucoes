using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucoes.Domain.Entities;

namespace Solucoes.Domain.Repositories
{
    public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>, IWriteOnlyRepository<TEntity, TKey>
        where TEntity : AggregateRoot
        where TKey : struct
    {

    }
}
