using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Auth
{
    public class ResetPasswordRequestDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
