using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Auth
{
    public class LoginResultDTO
    {
        public bool Succeeded { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public bool IsLockedOut { get; set; }
        public string? Error { get; set; }

        public static LoginResultDTO Failed(string message) =>
            new LoginResultDTO
            {
                Succeeded = false,
                Error = message
            };
    }
}
