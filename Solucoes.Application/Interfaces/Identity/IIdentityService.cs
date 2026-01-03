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
        Task<bool> ExistsAsync(string email);
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO model);
        Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model);
        Task LogoutAsync();
        Task<UsuarioResultDTO?> FindByIdAsync(int id);
        Task<bool> IsEmailConfirmedAsync(string email);
        Task<string?> GenerateEmailConfirmationTokenAsync(string email);
        Task<bool> VerifyEmailConfirmationTokenAsync(string email, string token);
        Task<string?> GeneratePasswordResetTokenAsync(string email);
        Task<ResetPasswordResultDTO> ResetPasswordAsync(ResetPasswordRequestDTO model);
    }
}
