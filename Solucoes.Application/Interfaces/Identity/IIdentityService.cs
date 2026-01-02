using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO model);
        Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model);
        Task LogoutAsync();
        Task<UsuarioDTO?> FindByIdAsync(int id);
    }
}
