using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Identity;

namespace Solucoes.Web.Claims
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly IUsuarioService _usuarioService;

        public ClaimsTransformation(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = new ClaimsIdentity();

            UsuarioDTO? usuario = null;

            if (!principal.HasClaim(claim => claim.Type == "PrimeiroNome"))
            {
                var usuarioId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!);
                usuario ??= await _usuarioService.ObterPeloIdAsync(usuarioId);
                if (usuario != null)
                {
                    identity.AddClaim(new Claim("PrimeiroNome", usuario.PrimeiroNome!));
                }
            }

            if (!principal.HasClaim(claim => claim.Type == "Sobrenome"))
            {
                var usuarioId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!);
                usuario ??= await _usuarioService.ObterPeloIdAsync(usuarioId);
                if (usuario != null)
                {
                    identity.AddClaim(new Claim("Sobrenome", usuario.Sobrenome!));
                }
            }

            principal.AddIdentity(identity);

            return principal;
        }
    }
}
