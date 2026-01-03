using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.Interfaces.Email;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Web.Areas.Conta.Models.Auth;
using System.Net.Mail;

namespace Solucoes.Web.Areas.Conta.Controllers
{
    [Area("conta")]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(
            IAuthService authService,
            IEmailService emailService
            )
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login(string? returnUrl = null)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _authService.ExistsAsync(model.Email!))
            {
                ModelState.AddModelError(string.Empty, "As credenciais informadas são inválidas!");
                return View(model);
            }

            if (!await _authService.IsEmailConfirmedAsync(model.Email!))
            {
                await SendEmailConfirmationTokenAsync(model.Email!);
                ViewBag.ConfirmEmailMessage = "Conta não confirmada! Verifique o link de confirmação que foi enviado para o seu e-mail!";
                return View(model);
            }

            var result = await _authService.LoginAsync(new LoginRequestDTO
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            });

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, result.Error!);
                return View(model);
            }

            if (model.ReturnUrl != null)
            {
                return LocalRedirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home", new { area = "Projetos" });
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.RegisterAsync(new RegisterRequestDTO
            {
                PrimeiroNome = model.PrimeiroNome,
                Sobrenome = model.Sobrenome,
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
            });

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    AddModelError(error);
                }
                return View(model);
            }

            await SendEmailConfirmationTokenAsync(model.Email!);

            TempData["SuccessMessage"] = "Cadastro realizado com sucesso! Verifique o link de confirmação que foi enviado para o seu e-mail!";

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        [Route("email-confirmation")]
        public async Task<IActionResult> ConfirmEmail(string? email, string? token)
        {
            var model = new ConfirmEmailViewModel();

            if (email == null)
            {
                model.Succeeded = false;
                model.Error = "O e-mail não foi fornecido.";

                return View(model);
            }

            if (token == null)
            {
                model.Succeeded = false;
                model.Error = "O token não foi fornecido.";

                return View(model);
            }
   
            var result = await _authService.VerifyEmailConfirmationTokenAsync(email, token);

            if (!result)
            {
                model.Succeeded = false;
                model.Error = "O token fornecido é inválido ou já expirou!";

                return View(model);
            }

            model.Succeeded = true;

            return View(model);
        }

        [HttpGet]
        [Route("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("forgot-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            return View();
        }

        private async Task SendEmailConfirmationTokenAsync(string email)
        {
            var token = await _authService.GenerateEmailConfirmationTokenAsync(email);

            var body = @$"
                <h1>Confirmação de Cadastro</h1>
                <h2>Obrigado por se cadastrar em nossa plataforma!</h2>
                <p>
                    Por favor, confirme seu cadastro clicando no link a seguir:
                    <a href='{Url.Action("ConfirmEmail", "Auth", new { area = "Conta", email, token = token! }, Request.Scheme)}'>Confirmar e-mail</a>
                </p>
            ";

            await _emailService.SendAsync(email, "Confirmação de Cadastro", body);
        }

        private void AddModelError(KeyValuePair<string, string> error)
        {
            switch (error.Key)
            {
                // Email
                case "DuplicateEmail":
                    ModelState.AddModelError("Email", "E-mail já está em uso.");
                    break;

                case "InvalidEmail":
                    ModelState.AddModelError("Email", "E-mail inválido!");
                    break;

                // UserName
                case "DuplicateUserName":
                    ModelState.AddModelError("UserName", "Nome de usuário já está em uso.");
                    break;

                case "InvalidUserName":
                    ModelState.AddModelError("UserName", "Nome de usuário inválido!");
                    break;

                // Password
                case "PasswordTooShort":
                    ModelState.AddModelError("Password", "A senha deve ter no mínimo 6 caracteres!");
                    break;

                case "PasswordRequiresNonAlphanumeric":
                    ModelState.AddModelError("Password", "A senha deve ter pelo menos um caractere especial!");
                    break;

                case "PasswordRequiresDigit":
                    ModelState.AddModelError("Password", "A senha deve ter pelo menos um número!");
                    break;

                case "PasswordRequiresUpper":
                    ModelState.AddModelError("Password", "A senha deve ter pelo menos uma letra maiúscula!");
                    break;

                // Outros
                default:
                    ModelState.AddModelError(string.Empty, $"Erro ao cadastrar usuário [{error.Key}]: {error.Value}");
                    break;
            }
        }
    }
}
