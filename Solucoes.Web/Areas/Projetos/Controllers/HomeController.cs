using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Web.Areas.Projetos.Models.Home;
using System.Security.Claims;

namespace Solucoes.Web.Areas.Projetos.Controllers
{
    [Authorize]
    [Area("projetos")]
    [Route("[area]")]
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProjetoService _projetoService;

        public HomeController(
            IUsuarioService usuarioService,
            IProjetoService projetoService
            )
        {
            _usuarioService = usuarioService;
            _projetoService = projetoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var usuario = await _usuarioService.ObterPeloIdAsync(usuarioId);

            ViewBag.UsuarioNome = usuario?.PrimeiroNome;

            var projetos = await _projetoService.ObterProjetosCriadosPeloUsuarioAsync(usuarioId);

            var model = projetos.Select(p => new ProjetoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                CriadoEm = p.CriadoEm,
                QuantidadeMembros = p.QuantidadeMembros,
            });

            return View(model);
        }
    }
}
