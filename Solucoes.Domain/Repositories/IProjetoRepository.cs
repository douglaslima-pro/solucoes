using Solucoes.Domain.Entities.Projetos;
using Solucoes.Domain.Repositories.Base;

namespace Solucoes.Domain.Repositories
{
    public interface IProjetoRepository : ICrudRepository<Projeto, int>
    {
        Task<IEnumerable<Projeto>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId);
    }
}
