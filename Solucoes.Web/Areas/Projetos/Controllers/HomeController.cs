using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.Interfaces.Services;
using System.Security.Claims;

namespace Solucoes.Web.Areas.Projetos.Controllers
{
    [Authorize]
    [Area("projetos")]
    [Route("[area]")]
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var usuario = await _usuarioService.FindByIdAsync(usuarioId);

            ViewBag.Nome = usuario?.PrimeiroNome;

            return View();
        }
    }
}
