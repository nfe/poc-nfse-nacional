using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFSENacionalClient.Util
{
    public class ValidacaoSchemaException : Exception
    {
        /// <summary>
        /// Houve erros de validação de schema XSD
        /// </summary>
        /// <param name="message"></param>
        public ValidacaoSchemaException(string message) : base(string.Format("Erros na validação:\n {0}", message)) { }
    }
}
