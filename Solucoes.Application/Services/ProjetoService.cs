using Solucoes.Application.DTOs.Projeto;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Domain.Repositories;

namespace Solucoes.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<ProjetoDTO?> ObterProjetoPeloIdAsync(int projetoId)
        {
            var dados = await _projetoRepository.ObterProjetoPeloIdAsync(projetoId);

            if (dados == null)
            {
                return null;
            }

            return new ProjetoDTO
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Descricao = dados.Descricao,
                CriadoPorUsuarioId = dados.CriadoPorUsuarioId,
                CriadoEm = dados.CriadoEm,
            };
        }

        public async Task<IEnumerable<ProjetoDTO>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId)
        {
            var dados = await _projetoRepository.ObterProjetosCriadosPeloUsuarioAsync(usuarioId);

            return dados.Select(x => new ProjetoDTO
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                CriadoEm = x.CriadoEm,
                CriadoPorUsuarioId = x.CriadoPorUsuarioId,
                QuantidadeMembros = x.Membros.Count()
            });
        }
    }
}
