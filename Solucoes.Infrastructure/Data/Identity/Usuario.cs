using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data.Identity
{
    public class Usuario : IdentityUser<int>
    {
        public string? PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
