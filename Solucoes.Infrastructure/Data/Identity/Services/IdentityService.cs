using Microsoft.AspNetCore.Identity;
using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Email;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Infrastructure.Data.Identity.Entities;
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
        private readonly IEmailService _emailService;

        public IdentityService(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IEmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<UsuarioResultDTO?> FindByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null;
            }

            return new UsuarioResultDTO
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

            var result = await _signInManager.PasswordSignInAsync(user!, model.Password!, model.RememberMe, false);

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
            var usuario = new Usuario
            {
                PrimeiroNome = model.PrimeiroNome,
                Sobrenome = model.Sobrenome,
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(usuario, model.Password!);

            return new RegisterResultDTO
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e =>
                {
                    return new KeyValuePair<string, string>(e.Code, e.Description);
                }).ToDictionary()
            };
        }
        
        public async Task<string?> GenerateEmailConfirmationTokenAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            return await _userManager.GenerateEmailConfirmationTokenAsync(usuario!);
        }

        public async Task<bool> VerifyEmailConfirmationTokenAsync(string email, string token)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(usuario!, token);
            return result.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            return await _userManager.IsEmailConfirmedAsync(usuario!);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<string?> GeneratePasswordResetTokenAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            return await _userManager.GeneratePasswordResetTokenAsync(usuario!);
        }

        public async Task<ResetPasswordResultDTO> ResetPasswordAsync(ResetPasswordRequestDTO model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.Email!);

            var result = await _userManager.ResetPasswordAsync(usuario!, model.Token!, model.Password!);

            return new ResetPasswordResultDTO
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e =>
                {
                    return new KeyValuePair<string, string>(e.Code, e.Description);
                }).ToDictionary()
            };
        }
    }
}
