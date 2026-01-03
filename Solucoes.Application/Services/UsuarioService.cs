using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IIdentityService _identityService;

        public UsuarioService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UsuarioResultDTO?> FindByIdAsync(int id)
        {
            return await _identityService.FindByIdAsync(id);
        }
    }
}
