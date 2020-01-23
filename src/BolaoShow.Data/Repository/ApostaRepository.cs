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
    public class ApostaRepository : Repository<Aposta>, IApostaRepository
    {
        public ApostaRepository(Contexto contexto) : base(contexto)
        {
        }
        // busca todas as apostas de um concurso
        public async Task<IEnumerable<Aposta>> ObterApostaDeUmConcurso(int numeroConcurso)
        {
            return await Db.Apostas.AsNoTracking().Where(a => a.Concurso.NumeroConcurso == numeroConcurso).ToListAsync();
        }
        //busca uma aposta
        public async Task<Aposta> ObterAposta(Guid id)
        {
            return await Db.Apostas.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
