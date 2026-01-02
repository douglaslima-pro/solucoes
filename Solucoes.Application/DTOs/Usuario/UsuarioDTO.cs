using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NomeCompleto => PrimeiroNome + " " + Sobrenome;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
