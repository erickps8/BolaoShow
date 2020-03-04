using BolaoShow.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface IApostaService : IDisposable
    {
        Task<bool> Adicionar(Aposta aposta);
        Task<bool> Atualizar(Aposta aposta);
    }
}
