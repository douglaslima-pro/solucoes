using Microsoft.EntityFrameworkCore;
using Solucoes.Domain.Entities.Projetos;
using Solucoes.Domain.Repositories;
using Solucoes.Infrastructure.Data.Repositories.Base;

namespace Solucoes.Infrastructure.Data.Repositories
{
    public class ProjetoRepository : CrudRepository<Projeto, int, SolucoesDbContext>, IProjetoRepository
    {
        public ProjetoRepository(SolucoesDbContext context) : base(context) { }

        public async Task<IEnumerable<Projeto>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId)
        {
            return await _entity
                .AsNoTracking()
                .Include(x => x.Membros)
                .Include(x => x.Sprints)
                .Where(x => x.CriadoPorUsuarioId == usuarioId)
                .OrderByDescending(x => x.CriadoEm)
                .ToListAsync();
        }
    }
}
