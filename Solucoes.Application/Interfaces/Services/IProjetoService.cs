using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucoes.Application.DTOs.Projeto;

namespace Solucoes.Application.Interfaces.Services
{
    public interface IProjetoService
    {
        Task<ProjetoDTO?> ObterProjetoPeloIdAsync(int projetoId);
        Task<IEnumerable<ProjetoDTO>> ObterProjetosCriadosPeloUsuarioAsync(int usuarioId);
    }
}
