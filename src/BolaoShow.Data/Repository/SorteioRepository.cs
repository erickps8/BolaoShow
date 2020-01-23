using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Data.Repository
{
    public class SorteioRepository : Repository<Sorteio>, ISorteioRepository
    {
        public SorteioRepository(Contexto contexto) : base(contexto)
        {
        }
        public async Task<IEnumerable<Sorteio>> ObterSorteiosPorConcurso(Guid concursoId)
        {
            return await Db.Sorteios.AsNoTracking().Include(c => c.Concurso).Where(c => c.Concurso.Id == concursoId).ToListAsync();
        }

        public async Task<IEnumerable<Sorteio>> ObterObterTodosConcurso()
        {
            return await Db.Sorteios.AsNoTracking().Include(c => c.Concurso).ToListAsync();
        }
    }
}
