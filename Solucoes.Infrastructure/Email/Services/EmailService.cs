using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Solucoes.Application.Interfaces.Email;
using System.Net;
using System.Security;

namespace Solucoes.Infrastructure.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _email;
        private readonly string? _password;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _email = _configuration["EmailSettings:Email"];
            _password = _configuration["EmailSettings:Password"];
        }

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
            message.From.Add(new MailboxAddress("Solucoes App", _email));

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            await smtpClient.AuthenticateAsync(_email, _password);
            
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
