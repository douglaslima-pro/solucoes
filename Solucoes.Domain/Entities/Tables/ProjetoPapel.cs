using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Domain.Entities.Tables
{
    public class ProjetoPapel
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool? Ativo { get; private set; }

        protected ProjetoPapel() { }

        public ProjetoPapel(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public ProjetoPapel(int id, string codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }
    }
}
