using System;
using System.Collections.Generic;

namespace BolaoShow.Bussiness.Models
{
    public class Aposta : Entity
    {
        public virtual int Dezena_01 { get; set; }
        public virtual int Dezena_02 { get; set; }
        public virtual int Dezena_03 { get; set; }
        public virtual int Dezena_04 { get; set; }
        public virtual int Dezena_05 { get; set; }
        public virtual decimal ValorAposta { get; set; }
        public virtual IEnumerable<Aposta_Sorteio> Sorteios { get; set; }
    }
}