using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BolaoShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApostaController : MainController
    {
        private readonly IApostaRepository _apostaRepository;
        private readonly IMapper _mapper;

        public ApostaController(INotificador notificador, IApostaRepository apostaRepository, ISorteioRepository sorteioRepository, IMapper mapper) : base(notificador)
        {
            _apostaRepository = apostaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostasSorteios());
        }
        [HttpGet("{apostaSorteio}/{id:guid}")]
        public async Task<IEnumerable<ApostaDto>> OberApostasSorteio(Guid Id)
        {
            return _mapper.Map <IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostaPorSorteio(Id));
        }
        [HttpGet("{id:guid}")]
        public async Task<ApostaDto> ObterAposta(Guid id)
        {
            return _mapper.Map<ApostaDto>(await _apostaRepository.ObterApostaSorteio(id));
        }

    }
}
