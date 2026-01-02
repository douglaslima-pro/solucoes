using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.DTOs.Auth;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Web.Areas.Conta.Models.Auth;

namespace Solucoes.Web.Areas.Conta.Controllers
{
    [Area("conta")]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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

            TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";

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
        [Route("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            return View();
        }

        private void AddModelError(string error)
        {
            switch (error)
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
                    ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuário:" + error);
                    break;
            }
        }
    }
}
