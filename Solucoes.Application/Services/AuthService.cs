using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityService _identityService;

        public AuthService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<LoginResultDTO> LoginAsync(LoginRequestDTO model)
        {
            if (model.Email == null)
            {
                return LoginResultDTO.Failed("Email é obrigatório.");
            }

            return await _identityService.LoginAsync(model);
        }

        public async Task LogoutAsync()
        {
            await _identityService.LogoutAsync();
        }

        public async Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model)
        {
            return await _identityService.RegisterAsync(model);
        }
    }
}
