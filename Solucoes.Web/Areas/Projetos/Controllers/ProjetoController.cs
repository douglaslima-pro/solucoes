using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Application.Interfaces.Services;
using Solucoes.Web.Areas.Projetos.Models.Home;

namespace Solucoes.Web.Areas.Projetos.Controllers
{
    [Authorize]
    [Area("projetos")]
    [Route("[area]")]
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var dados = await _projetoService.ObterProjetoPeloIdAsync(id);

            var model = new ProjetoViewModel
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Descricao = dados.Descricao,
                CriadoEm = dados.CriadoEm,
            };

            return View(model);
        }
    }
}
