using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Dtos
{
    public class ConcursoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroConcurso { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicioConcurso { get; set; }
        public DateTime DataFimConcurso { get; set; }
    }
}
