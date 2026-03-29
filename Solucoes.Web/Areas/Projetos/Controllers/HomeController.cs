using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Web.Areas.Projetos.Models.Projeto;
using System.Security.Claims;

namespace Solucoes.Web.Areas.Projetos.Controllers
{
    [Authorize]
    [Area("projetos")]
    [Route("[area]")]
    public class HomeController : Controller
    {
        private readonly IProjetoService _projetoService;

        public HomeController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

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

        [HttpGet]
        [Route("meus-projetos")]
        public async Task<IActionResult> Projetos()
        {
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var projetos = await _projetoService.ObterProjetosCriadosPeloUsuarioAsync(usuarioId);

            var model = projetos.Select(p => new ProjetoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                CriadoEm = p.CriadoEm,
                QuantidadeMembros = p.QuantidadeMembros,
                QuantidadeSprints = p.QuantidadeSprints
            });

            return PartialView("_Projetos", model);
        }
    }
}
