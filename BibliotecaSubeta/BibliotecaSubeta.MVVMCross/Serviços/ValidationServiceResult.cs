using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public class ValidationServiceResult
    {
        public bool Resultado { get; set; }
        public List<ValidationResult> Mensagens { get; set; }

        public ValidationServiceResult()
        {
            Mensagens = new List<ValidationResult>();
        }
    }
}
