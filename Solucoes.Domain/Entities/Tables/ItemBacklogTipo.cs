using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Domain.Entities.Tables
{
    public class ItemBacklogTipo
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool? Ativo { get; private set; }
        
        protected ItemBacklogTipo() { }

        public ItemBacklogTipo(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public ItemBacklogTipo(int id, string codigo, string nome)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
        }
    }
}
