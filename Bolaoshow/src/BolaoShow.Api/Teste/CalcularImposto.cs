using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Teste
{
    public class CalcularImposto : ICalcularImposto
    {
        public decimal Executar(ITipoImposto tipoImposto, NotaFiscal notaFiscal)
        {
            return tipoImposto.Calcular(notaFiscal);
        }
    }
}
