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
        public IEnumerable<string> Errors { get; set; }

        public RegisterResultDTO()
        {
            Errors = new List<string>();
        }

        public static RegisterResultDTO Failed(IEnumerable<string> errors) =>
            new RegisterResultDTO
            {
                Succeeded = false,
                Errors = errors
            };
    }
}
