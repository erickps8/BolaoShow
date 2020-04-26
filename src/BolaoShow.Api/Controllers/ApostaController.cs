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
        private readonly IConcursoRepository _concursoRepository;
        private readonly IMapper _mapper;

        public ApostaController(INotificador notificador, IValidaApostasService validaApostaService, IApostaRepository apostaRepository, IApostaService apostaService, IConcursoRepository concursoRepository, IMapper mapper, IUser user) : base(notificador, user)
        {
            _apostaService = apostaService;
            _apostaRepository = apostaRepository;
            _validaApostaService = validaApostaService;
            _concursoRepository = concursoRepository;
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
                await _validaApostaService.ValidaDezena_5(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_6(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_7(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_8(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_9(await _apostaRepository.ObterAposta(id)),
                await _validaApostaService.ValidaDezena_10(await _apostaRepository.ObterAposta(id))
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
        public async Task<IEnumerable<ApostaDto>> ObterApostDeUmConcurso(int numeroConcurso)
        {
            return _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostaDeUmConcurso(numeroConcurso));
        }

        [Route("apostaConcursoVigente")]
        [HttpGet]
        public async Task<IEnumerable<ApostaDto>> ObterApostaConcursoVigente()
        {
            if (_concursoRepository.ObterConcursoVigente() == null) return null;
            
            var apostas = _mapper.Map<IEnumerable<ApostaDto>>(await _apostaRepository.ObterApostaDeUmConcurso(_concursoRepository.ObterConcursoVigente().NumeroConcurso));

            foreach (var item in apostas)
            {
                item.Estado_Dezena_01 = await _validaApostaService.ValidaDezena_1(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_02 = await _validaApostaService.ValidaDezena_2(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_03 = await _validaApostaService.ValidaDezena_3(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_04 = await _validaApostaService.ValidaDezena_4(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_05 = await _validaApostaService.ValidaDezena_5(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_06 = await _validaApostaService.ValidaDezena_6(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_07 = await _validaApostaService.ValidaDezena_7(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_08 = await _validaApostaService.ValidaDezena_8(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_09 = await _validaApostaService.ValidaDezena_9(_mapper.Map<Aposta>(item));
                item.Estado_Dezena_10 = await _validaApostaService.ValidaDezena_10(_mapper.Map<Aposta>(item));
            }
            return apostas;
        }

        [HttpGet("{id:Guid}")]
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

        [HttpPost]
        public async Task<ActionResult<ApostaDto>> Adicionar(ApostaDto apostaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _apostaService.Adicionar(_mapper.Map<Aposta>(apostaDto));

            return CustomResponse(apostaDto);
        }

        [HttpPut("{id:Guid}")]
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
