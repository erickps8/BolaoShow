using BolaoShow.Bussiness.Models;
using System;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface IConcursoService : IDisposable
    {
        Task<bool> Adicionar(Concurso concurso);
        Task<bool> Atualizar(Concurso concurso);
    }
}
