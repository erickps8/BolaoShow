using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Teste
{
    public class ICMSImposto : ITipoImposto
    {
        public decimal Calcular(NotaFiscal notaFiscal)
        {
            return notaFiscal.Valor * 0.04M;
        }
    }
}
