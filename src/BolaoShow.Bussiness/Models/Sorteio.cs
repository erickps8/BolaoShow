using System;
using System.ComponentModel.DataAnnotations;

namespace BolaoShow.Bussiness.Models
{
    public class Sorteio : Entity
    {
        public int Dezena_01 { get; set; }
        public int Dezena_02 { get; set; }
        public int Dezena_03 { get; set; }
        public int Dezena_04 { get; set; }
        public int Dezena_05 { get; set; }
        public DateTime Data { get; set; }
        public Guid ConcursoId { get; set; }
        public Concurso Concurso { get; set; }
    }
}
