using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoShow.Bussiness.Models
{
    public class Concurso : Entity
    {
        public string Descricao { get; set; }
        public int NumeroConcurso { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicioConcurso { get; set; }
        public DateTime DataFimConcurso { get; set; }
    }
}
