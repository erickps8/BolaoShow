using System;
using System.ComponentModel.DataAnnotations;

namespace BolaoShow.Api.Dtos
{
    public class ApostaDto
    {
        [Key]
        public Guid Id { get; set; }
        public int Dezena_01 { get; set; }
        public int Dezena_02 { get; set; }
        public int Dezena_03 { get; set; }
        public int Dezena_04 { get; set; }
        public int Dezena_05 { get; set; }
        public bool Estado_Dezena_01 { get; set; }
        public bool Estado_Dezena_02 { get; set; }
        public bool Estado_Dezena_03 { get; set; }
        public bool Estado_Dezena_04 { get; set; }
        public bool Estado_Dezena_05 { get; set; }
        public decimal ValorAposta { get; set; }
        public Guid ConcursoId { get; set; }
        public ConcursoDto Concurso { get; set; }
        public Guid UserId { get; set; }
    }
}
