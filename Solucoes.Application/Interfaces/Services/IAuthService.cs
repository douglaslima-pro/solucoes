using Solucoes.Application.DTOs.Auth;

namespace Solucoes.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> ExistsAsync(string email);
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO model);
        Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO model);
        Task LogoutAsync();
        Task<bool> IsEmailConfirmedAsync(string email);
        Task<string?> GenerateEmailConfirmationTokenAsync(string email);
        Task<bool> VerifyEmailConfirmationTokenAsync(string email, string token);
        Task<string?> GeneratePasswordResetTokenAsync(string email);
        Task<ResetPasswordResultDTO> ResetPasswordAsync(ResetPasswordRequestDTO model);
    }
}
