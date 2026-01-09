using Solucoes.Domain.Entities.Projetos;

namespace Solucoes.Domain.Repositories
{
    public interface IProjetoRepository : ICrudRepository<Projeto, int>
    {
        Task<IEnumerable<Projeto>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId);
    }
}
