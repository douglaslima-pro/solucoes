using Microsoft.EntityFrameworkCore;
using Solucoes.Domain.Entities;
using Solucoes.Domain.Repositories.Base;

namespace Solucoes.Infrastructure.Data.Repositories.Base
{
    /// <summary>
    /// Implementação da interface <see cref="IRepository"/> utilizando Entity Framework Core
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade</typeparam>
    /// <typeparam name="TContext">Tipo da classe de contexto</typeparam>
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : AggregateRoot
        where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _entity;

        protected Repository(TContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
