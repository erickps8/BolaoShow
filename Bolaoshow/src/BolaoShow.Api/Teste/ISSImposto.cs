using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Teste
{
    public class ISSImposto : ITipoImposto
    {
        public decimal Calcular(NotaFiscal notaFiscal)
        {
            return notaFiscal.Valor * 0.02M;
        }
    }
}
