using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class ValidaApostasService : IValidaApostasService
    {
        private readonly ISorteioRepository _sorteioRepository;
        public ValidaApostasService(ISorteioRepository sorteioRepository)
        {
            _sorteioRepository = sorteioRepository;
        }
        public async Task<bool> ValidaDezena_1(Aposta aposta)
        {
            IEnumerable<Sorteio> sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_01.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_01.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_01.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_01.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_01.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_2(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_02.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_02.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_02.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_02.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_02.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_3(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_03.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_03.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_03.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_03.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_03.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_4(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_04.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_04.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_04.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_04.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_04.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_5(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_05.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_05.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_05.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_05.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_05.Equals(x.Dezena_05))) return true;

            return false;
        }
    }
}
