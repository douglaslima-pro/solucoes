using Microsoft.AspNetCore.Identity;
using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AuthService(
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
                Errors = result.Errors.Select(e =>
                {
                    return new KeyValuePair<string, string>(e.Code, e.Description);
                }).ToDictionary()
            };
        }
        
        public async Task<string?> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GenerateEmailConfirmationTokenAsync(user!);
        }

        public async Task<bool> VerifyEmailConfirmationTokenAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(user!, token);
            return result.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.IsEmailConfirmedAsync(user!);
        }

        public async Task<string?> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GeneratePasswordResetTokenAsync(user!);
        }

        public async Task<ResetPasswordResultDTO> ResetPasswordAsync(ResetPasswordRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email!);

            var result = await _userManager.ResetPasswordAsync(user!, model.Token!, model.Password!);

            return new ResetPasswordResultDTO
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e =>
                {
                    return new KeyValuePair<string, string>(e.Code, e.Description);
                }).ToDictionary()
            };
        }

        public async Task<bool> CheckPasswordAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }
    }
}
