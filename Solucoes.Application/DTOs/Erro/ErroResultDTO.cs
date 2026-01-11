using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Erro
{
    public class ErroResultDTO
    {
        public IDictionary<string, string> Erros { get; set; }

        public ErroResultDTO()
        {
            Erros = new Dictionary<string, string>();
        }

        public void AdicionarErro(string codigo, string mensagem)
        {
            Erros.Add(codigo, mensagem);
        }
    }
}
