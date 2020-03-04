using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BolaoShow.Bussiness.Models
{
    public class Aposta_Sorteio : Entity
    {        
        public Aposta Aposta { get; set; }
        public Guid ApostaId { get; set; }
        public Sorteio Sorteio { get; set; }
        public Guid SorteioId { get; set; }
    }
}
