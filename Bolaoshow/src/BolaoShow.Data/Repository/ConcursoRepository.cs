using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Interfaces;
using System;
using System.Threading.Tasks;
using BolaoShow.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BolaoShow.Data.Repository
{
    public class ConcursoRepository : Repository<Concurso>, IConcursoRepository
    {
        public ConcursoRepository(Contexto contexto) : base(contexto)
        {
        }
        
    }

}
