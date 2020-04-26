using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Data.Context;
using System.Linq;

namespace BolaoShow.Data.Repository
{
    public class ConcursoRepository : Repository<Concurso>, IConcursoRepository
    {
        public ConcursoRepository(Contexto contexto) : base(contexto)
        {
        }

        public Concurso ObterConcursoVigente()
        {            
            return Db.Concurso.FirstOrDefault(c => c.Ativo.Equals(true));
        }
    }

}
