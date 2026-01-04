using Microsoft.AspNetCore.Identity;
using Solucoes.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data.Identity.Entities
{
    public class Usuario : IdentityUser<int>
    {
        public string? PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<ProjetoMembro> Projetos { get; set; }
    }
}
