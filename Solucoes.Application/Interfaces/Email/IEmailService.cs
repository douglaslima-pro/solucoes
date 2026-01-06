using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Interfaces.Email
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body, bool isHtml = true);
        Task SendEmailConfirmationTokenAsync(string email, string token);
        Task SendResetPasswordTokenAsync(string email, string token);
    }
}
