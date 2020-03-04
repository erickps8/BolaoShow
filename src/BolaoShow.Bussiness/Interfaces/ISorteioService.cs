using BolaoShow.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface ISorteioService : IDisposable
    {
        Task<bool> Adicionar(Sorteio sorteio);
        Task<bool> Atualizar(Sorteio sorteio);

    }
}
