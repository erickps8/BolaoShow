using BolaoShow.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface IApostaRepository : IRepository<Aposta>
    {
        Task<IEnumerable<Aposta>> ObterApostaDeUmConcurso(int numeroConcurso);
        Task<Aposta> ObterAposta(Guid id);
    }
}
