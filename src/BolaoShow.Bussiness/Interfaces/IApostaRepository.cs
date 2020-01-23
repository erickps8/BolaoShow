using BolaoShow.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface IApostaRepository : IRepository<Aposta_Sorteio>
    {
        Task<IEnumerable<Aposta_Sorteio>> ObterApostaPorSorteio(Guid SorteioId);
        Task<IEnumerable<Aposta_Sorteio>> ObterApostasSorteios();
        Task<Aposta_Sorteio> ObterApostaSorteio(Guid id);
    }
}
