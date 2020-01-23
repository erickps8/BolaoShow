using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BolaoShow.Data.Repository
{
    public class SorteioRepository : Repository<Sorteio>, ISorteioRepository
    {
        public SorteioRepository(Contexto contexto) : base(contexto)
        {
        }
        public async Task<Sorteio> ObterSorteioAposta(Guid id)
        {
            return await Db.Sorteios
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
