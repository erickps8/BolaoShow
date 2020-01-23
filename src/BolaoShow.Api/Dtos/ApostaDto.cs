using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Dtos
{
    public class ApostaDto
    {
        [Key]
        public Guid SorteioId { get; set; }
        public int Dezena_01 { get; set; }
        public int Dezena_02 { get; set; }
        public int Dezena_03 { get; set; }
        public int Dezena_04 { get; set; }
        public int Dezena_05 { get; set; }
        public decimal ValorAposta { get; set; }
        public virtual IEnumerable<SorteioDto> Sorteios { get; set; }
    }
}
