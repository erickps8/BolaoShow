using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BolaoShow.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApostaController : MainController
    {
        private readonly IApostaRepository _apostaRepository;
        private readonly IApostaService _apostaService;
        private readonly IValidaApostasService _validaApostaService;
        private readonly IMapper _mapper;

        public ApostaController(INotificador notificador, IValidaApostasService validaApostaService, IApostaRepository apostaRepository, IApostaService apostaService, IMapper mapper, IUser user) : base(notificador, user)
        {
            _apostaService = apostaService;
            _apostaRepository = apostaRepository;
            _validaApostaService = validaApostaService;
            _mapper = mapper;
        }
        [Route("ValidaDezenasAcertadas/{id:Guid}")]
        [HttpGet]
        public async Task<List<bool>> ValidaDezenasAcertadas(Guid id)
        {
            var lst = new List<bool>() {
                await _validaApostaService.ValidaDezena_1(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_2(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_3(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_4(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_5(await _apostaRepository.ObterAposta(id))
            };

            return lst;
        }

        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterTodos()
        {           
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterTodos());
        }
        [Route("apostaConcurso/{numeroConcurso:int}")]
        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterApostaPorDeUmConcurso(int numeroConcurso)
        {
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostaDeUmConcurso(numeroConcurso));
        }
        [HttpGet("{id:guid}")]
        public async Task<ApostaDto> ObterAposta(Guid id)
        {
            return _mapper.Map<ApostaDto>(await _apostaRepository.ObterAposta(id));
        }
        [Route("minhasApostas/{numeroConcurso:int}")]
        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterApostasDoUsuario(int numeroConcurso)
        {
            var id = AppUser.GetUserId();
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostasDoUsuario(id, numeroConcurso));
        }

        [HttpPost("{id:guid}")]
        public async Task<ActionResult<ApostaDto>> Adicionar(ApostaDto apostaDto, Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _apostaService.Adicionar(_mapper.Map<Aposta>(apostaDto), id);

            return CustomResponse(apostaDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SorteioDto>> Atualizar(Guid id, ApostaDto apostaDto)
        {
            if (id != apostaDto.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(apostaDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _apostaService.Atualizar(_mapper.Map<Aposta>(apostaDto));

            return CustomResponse(apostaDto);
        }

    }
}
