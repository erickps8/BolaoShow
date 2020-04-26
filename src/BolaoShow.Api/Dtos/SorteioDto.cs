using System;

namespace BolaoShow.Api.Dtos
{
    public class SorteioDto
    {
        public Guid Id { get; set; }
        public int Dezena_01 { get; set; }
        public int Dezena_02 { get; set; }
        public int Dezena_03 { get; set; }
        public int Dezena_04 { get; set; }
        public int Dezena_05 { get; set; }
        public DateTime Data { get; set; }
        public Guid ConcursoId { get; set; }
        public ConcursoDto Concurso { get; set; }
    }
}
