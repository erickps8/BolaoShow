using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Teste
{
    interface ICalcularImposto
    {
        decimal Executar(ITipoImposto tipoImposto, NotaFiscal notaFiscal);
    }
}
