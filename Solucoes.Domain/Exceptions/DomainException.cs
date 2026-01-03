using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string FieldName { get; set; }

        public DomainException(string fieldName) : base()
        {
            FieldName = fieldName;
        }

        public DomainException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
        public DomainException(string fieldName, string message, Exception innerException) : base(message, innerException)
        {
            FieldName = fieldName;
        }
    }
}
