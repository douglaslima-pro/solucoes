using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Auth
{
    public class RegisterRequestDTO
    {
        public string? PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
