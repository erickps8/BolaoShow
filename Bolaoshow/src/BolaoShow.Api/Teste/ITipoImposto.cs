using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Teste
{
    public interface ITipoImposto
    {
        decimal Calcular(NotaFiscal notaFiscal);
    }
}
