using Microsoft.AspNetCore.Identity;
using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public IdentityService(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UsuarioDTO?> FindByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null;
            }

            return new UsuarioDTO
            {
                Id = user.Id,
                PrimeiroNome = user.PrimeiroNome,
                Sobrenome = user.Sobrenome,
                UserName = user.UserName,
                Email = user.Email,
                IsActive = user.IsActive
            };
        }

        public async Task<LoginResultDTO> LoginAsync(LoginRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user == null)
            {
                return LoginResultDTO.Failed("As credenciais informadas são inválidas!");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password!, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return LoginResultDTO.Failed("As credenciais informadas são inválidas!");
            }

            return new LoginResultDTO
            {
                Succeeded = result.Succeeded,
                RequiresTwoFactor = result.RequiresTwoFactor,
                IsLockedOut = result.IsLockedOut
            };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model)
        {
            var user = new Usuario
            {
                PrimeiroNome = model.PrimeiroNome,
                Sobrenome = model.Sobrenome,
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            return new RegisterResultDTO
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => e.Code).ToList()
            };
        }
    }
}
