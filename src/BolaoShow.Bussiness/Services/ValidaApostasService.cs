﻿using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class ValidaApostasService : IValidaApostasService
    {
        private readonly ISorteioRepository _sorteioRepository;
        private readonly IConcursoRepository _concursoRepository;
        public ValidaApostasService(ISorteioRepository sorteioRepository, IConcursoRepository concursoRepository)
        {
            _sorteioRepository = sorteioRepository;
            _concursoRepository = concursoRepository;
        }
        public Concurso ConcursoVigente()
        {            
            return _concursoRepository.ObterConcursoVigente();
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
        public async Task<bool> ValidaDezena_6(Aposta aposta)
        {
            IEnumerable<Sorteio> sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_06.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_06.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_06.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_06.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_06.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_7(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_07.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_07.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_07.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_07.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_07.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_8(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_08.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_08.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_08.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_08.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_08.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_9(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_09.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_09.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_09.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_09.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_09.Equals(x.Dezena_05))) return true;

            return false;
        }

        public async Task<bool> ValidaDezena_10(Aposta aposta)
        {
            var sorteiosConcurso = await _sorteioRepository.ObterSorteiosPorConcurso(aposta.ConcursoId);

            if (sorteiosConcurso.Any(x => aposta.Dezena_10.Equals(x.Dezena_01))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_10.Equals(x.Dezena_02))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_10.Equals(x.Dezena_03))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_10.Equals(x.Dezena_04))) return true;
            if (sorteiosConcurso.Any(x => aposta.Dezena_10.Equals(x.Dezena_05))) return true;

            return false;
        }
    }
}
