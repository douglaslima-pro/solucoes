using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Solucoes.Application.DTOs.Usuario;
using Solucoes.Application.Interfaces.Identity;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data.Identity.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UsuarioDTO?> ObterPeloIdAsync(int id)
        {
            var usuario = await _userManager.FindByIdAsync(id.ToString());

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDTO
            {
                Id = usuario.Id,
                PrimeiroNome = usuario.PrimeiroNome,
                Sobrenome = usuario.Sobrenome,
                UserName = usuario.UserName,
                Email = usuario.Email,
                IsActive = usuario.IsActive,
            };
        }
    }
}
