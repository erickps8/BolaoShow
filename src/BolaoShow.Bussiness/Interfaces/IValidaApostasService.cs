using BolaoShow.Bussiness.Models;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface IValidaApostasService
    {
        Concurso ConcursoVigente();
        Task<bool> ValidaDezena_1(Aposta aposta);
        Task<bool> ValidaDezena_2(Aposta aposta);
        Task<bool> ValidaDezena_3(Aposta aposta);
        Task<bool> ValidaDezena_4(Aposta aposta);
        Task<bool> ValidaDezena_5(Aposta aposta);
    }
}
