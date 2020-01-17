using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolaoShow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : MainController
    {
        private readonly ISorteioService _sorteioService;
        private readonly IMapper _mapper;

        public SorteioController(ISorteioRepository sorteioRepository,
                                      IMapper mapper,
                                      ISorteioService sorteioService,
                                      INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _sorteioService = sorteioService;
        }

        [HttpPost]
        public async Task<ActionResult<SorteioDto>> Adicionar(SorteioDto sorteioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sorteioService.Adicionar(_mapper.Map<Sorteio>(sorteioDto));

            return CustomResponse(sorteioDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Aposta_SorteioDto>> Atualizar(Guid id, Aposta_SorteioDto Aaosta_SorteioDto)
        {
            if (id != Aaosta_SorteioDto.SorteioId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(Aaosta_SorteioDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sorteioService.Atualizar(_mapper.Map<Sorteio>(Aaosta_SorteioDto));

            return CustomResponse(Aaosta_SorteioDto);
        }

    }
}
