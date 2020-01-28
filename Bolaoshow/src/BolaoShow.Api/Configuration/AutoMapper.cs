using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoShow.Api.Configuration
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Concurso, ConcursoDto>().ReverseMap();
            CreateMap<Aposta, ApostaDto>().ReverseMap();
            CreateMap<Sorteio, SorteioDto>().ReverseMap();
            
        }
    }
}
