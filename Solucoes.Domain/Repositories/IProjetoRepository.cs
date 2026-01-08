using Solucoes.Domain.Entities.Projetos;

namespace Solucoes.Domain.Repositories
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<Projeto?> ObterProjetoPeloIdAsync(int projetoId);
        Task<IEnumerable<Projeto>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId);
    }
}
