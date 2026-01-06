using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Solucoes.Application.Interfaces.Email;

namespace Solucoes.Infrastructure.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IConfiguration _configuration;

        private readonly string? _email;
        private readonly string? _password;

        public EmailService(
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            IConfiguration configuration
            )
        {
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
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

        public async Task SendEmailConfirmationTokenAsync(string email, string token)
        {
            var body = @$"
                <h1>Confirmação de Cadastro</h1>
                <h2>Obrigado por se cadastrar em nossa plataforma!</h2>
                <p>
                    Por favor, confirme seu cadastro clicando no link:
                    <a href='{_urlHelper.Action("ConfirmEmail", "Auth", new { area = "Conta", email, token = token! })}'>Confirmar e-mail</a>
                </p>
            ";

            await SendAsync(email, "Confirmação de Cadastro", CreateHtml("Confirmação de Cadastro", body));
        }

        public async Task SendResetPasswordTokenAsync(string email, string token)
        {
            var body = @$"
                    <h1>Redefinição de Senha</h1>
                    <h2>Você solicitou a redefinição de sua senha.</h2>
                    <p>
                        Clique no link para prosseguir:
                        <a href='{_urlHelper.Action("ResetPassword", "Auth", new { area = "Conta", email = email!, token = token! })}'>Redefinir Senha</a>
                    </p>
                    <p>
                        Se você não solicitou essa alteração, por favor ignore este e-mail.
                    </p>
                ";

            await SendAsync(email, "Redefinição de Senha", CreateHtml("Redefinição de Senha", body));
        }

        private static string CreateHtml(string title, string body, string? style = null)
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""pt-BR"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width;initial-scale=1.0"">
                        <title>{title}</title>
                        <style>{style}</style>
                    </head>
                    <body>{body}</body>
                </html>
            ";
        }
    }
}
