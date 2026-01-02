using Solucoes.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO model);
        Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model);
        Task LogoutAsync();
    }
}
