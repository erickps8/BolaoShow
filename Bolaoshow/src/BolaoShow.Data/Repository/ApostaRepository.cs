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
    public class ApostaRepository : Repository<Aposta_Sorteio>, IApostaRepository
    {
        public ApostaRepository(Contexto contexto) : base(contexto)
        {
        }
        public async Task<IEnumerable<Aposta_Sorteio>> ObterApostaPorSorteio(Guid SorteioId)
        {
            return await Buscar(a => a.Sorteio.Id == SorteioId);
        }

        public async Task<Aposta_Sorteio> ObterApostaSorteio(Guid id)
        {
            return await Db.Aposta_Sorteios.AsNoTracking().Include(f => f.Sorteio)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Aposta_Sorteio>> ObterApostasSorteios()
        {
            return await Db.Aposta_Sorteios.AsNoTracking().Include(f => f.Sorteio)
                .ToListAsync();
        }
    }
}
