using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class ConcursoService : BaseService, IConcursoService
    {
        private readonly IConcursoRepository _concursoRepository;
        public ConcursoService(IConcursoRepository concursoRepository, INotificador notificador) : base(notificador)
        {
            _concursoRepository = concursoRepository;
        }
    
        public async Task<bool> Adicionar(Concurso concurso)
        {
            if (!ExecutarValidacao(new ConcursoValidation(), concurso)) return false;

            await _concursoRepository.Adicionar(concurso);
            return true;
        }
    

        public async Task<bool> Atualizar(Concurso concurso)
        {
            if (!ExecutarValidacao(new ConcursoValidation(), concurso)) return false;

            await _concursoRepository.Atualizar(concurso);
            return true;
        }

        public void Dispose()
        {
            _concursoRepository?.Dispose();
        }
    }
}
