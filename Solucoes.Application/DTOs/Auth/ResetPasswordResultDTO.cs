using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Auth
{
    public class ResetPasswordResultDTO
    {
        public bool Succeeded { get; set; }
        public IDictionary<string, string> Errors { get; set; }

        public ResetPasswordResultDTO()
        {
            Errors = new Dictionary<string, string>();
        }
    }
}
