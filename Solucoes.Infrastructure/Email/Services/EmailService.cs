using Google.Apis.Auth.OAuth2;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Solucoes.Application.Interfaces.Email;
using System.Net;
using System.Security;

namespace Solucoes.Infrastructure.Email.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string to, string subject, string body, bool isHtml = true)
        {
            var message = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart(isHtml ? TextFormat.Html : TextFormat.Plain)
                {
                    Text = body,
                }
            };
            message.To.Add(new MailboxAddress("", to));
            message.From.Add(new MailboxAddress("Solucoes App", "noreply.solucoes.app@gmail.com"));

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            var userName = Environment.GetEnvironmentVariable("SOLUCOES_USERNAME", EnvironmentVariableTarget.Machine);
            var password = Environment.GetEnvironmentVariable("SOLUCOES_PASSWORD", EnvironmentVariableTarget.Machine);

            await smtpClient.AuthenticateAsync(userName, password);
            
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
