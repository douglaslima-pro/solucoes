using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Auth
{
    public class RegisterResultDTO
    {
        public bool Succeeded { get; set; }
        public IDictionary<string, string> Errors { get; set; }

        public RegisterResultDTO()
        {
            Errors = new Dictionary<string, string>();
        }
    }
}
