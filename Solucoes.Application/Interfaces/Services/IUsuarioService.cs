using Solucoes.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioResultDTO?> FindByIdAsync(int id);
    }
}
