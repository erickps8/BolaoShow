using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace BolaoShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApostaController : MainController
    {
        private readonly IApostaRepository _apostaRepository;
        private readonly IApostaService _apostaService;
        private readonly IMapper _mapper;

        public ApostaController(INotificador notificador, IApostaRepository apostaRepository, IApostaService apostaService, IMapper mapper) : base(notificador)
        {
            _apostaService = apostaService;
            _apostaRepository = apostaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterTodos()
        {           
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterTodos());
        }
        [HttpGet("{apostaConcurso}/{numeroConcurso:int}")]
        public async Task<IEnumerable<ApostaDto>> ObterApostaPorDeUmConcurso(int numeroConcurso)
        {
            return _mapper.Map <IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostaDeUmConcurso(numeroConcurso));
        }
        [HttpGet("{id:guid}")]
        public async Task<ApostaDto> ObterAposta(Guid id)
        {
            return _mapper.Map<ApostaDto>(await _apostaRepository.ObterAposta(id));
        }

        [HttpPost]
        public async Task<ActionResult<ApostaDto>> Adicionar(ApostaDto apostaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _apostaService.Adicionar(_mapper.Map<Aposta>(apostaDto));

            return CustomResponse(apostaDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SorteioDto>> Atualizar(Guid id, ApostaDto apostaDto)
        {
            if (id != apostaDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(apostaDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _apostaService.Atualizar(_mapper.Map<Aposta>(apostaDto));

            return CustomResponse(apostaDto);
        }

    }
}
