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
    public class SorteioController : MainController
    {
        private readonly ISorteioRepository _sorteioRepository;
        private readonly ISorteioService _sorteioService;
        private readonly IMapper _mapper;

        public SorteioController(ISorteioRepository sorteioRepository,
                                      IMapper mapper,
                                      ISorteioService sorteioService,
                                      INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _sorteioService = sorteioService;
            _sorteioRepository = sorteioRepository;
        }
        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<SorteioDto>> ObterSorteiosPorConcurso(Guid Id)
        {
            return _mapper.Map<IEnumerable<SorteioDto>>(await _sorteioRepository.ObterSorteiosPorConcurso(Id));
        }

        [HttpGet]
        public async Task<IEnumerable<SorteioDto>> Obtertodos()
        {
            return _mapper.Map<IEnumerable<SorteioDto>>(await _sorteioRepository.ObterObterTodosConcurso());
        }

        [HttpPost]
        public async Task<ActionResult<SorteioDto>> Adicionar(SorteioDto sorteioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sorteioService.Adicionar(_mapper.Map<Sorteio>(sorteioDto));

            return CustomResponse(sorteioDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SorteioDto>> Atualizar(Guid id, SorteioDto SorteioDto)
        {
            if (id != SorteioDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(SorteioDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sorteioService.Atualizar(_mapper.Map<Sorteio>(SorteioDto));

            return CustomResponse(SorteioDto);
        }

    }
}
