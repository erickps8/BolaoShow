using System;

namespace BolaoShow.Api.Dtos
{
    public class Aposta_SorteioDto
    {
        public ApostaDto Aposta { get; set; }
        public Guid ApostaId { get; set; }
        public SorteioDto Sorteio { get; set; }
        public Guid SorteioId { get; set; }
    }
}
