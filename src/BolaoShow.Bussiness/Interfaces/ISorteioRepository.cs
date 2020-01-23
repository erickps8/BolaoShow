using BolaoShow.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface ISorteioRepository : IRepository<Sorteio>
    {        
        Task<Sorteio> ObterSorteioAposta(Guid id);
    }
}
