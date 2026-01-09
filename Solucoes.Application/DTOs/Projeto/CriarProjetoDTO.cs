using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Application.DTOs.Projeto
{
    public class CriarProjetoDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int CriadoPorUsuarioId { get; set; }
    }
}
