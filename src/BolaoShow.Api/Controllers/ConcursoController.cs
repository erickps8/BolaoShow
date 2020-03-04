using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Api.Extensions;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BolaoShow.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConcursoController : MainController
    {
        private readonly IConcursoRepository _concursoRepository;
        private readonly IConcursoService _concursoService;
        private readonly IMapper _mapper;

        public ConcursoController(IConcursoRepository concursoRepository, IMapper mapper, IConcursoService concursoService,
                                      INotificador notificador, IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _concursoService = concursoService;
            _concursoRepository = concursoRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<ConcursoDto> ObterPorId(Guid Id)
        {
            return _mapper.Map<ConcursoDto>(await _concursoRepository.ObterPorId(Id));
        }

        [HttpGet]
        public async Task<IEnumerable<ConcursoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ConcursoDto>>(await _concursoRepository.ObterTodos());
        }

        [HttpGet("concursoVigente")]
        public ActionResult ObterConcursoVigente()
        {            
                var concursoVigente = _mapper.Map<ConcursoDto>(_concursoRepository.ObterConcursoVigente());
                return Ok(concursoVigente);
        }

        [ClaimsAuthorize("Administrador", "Administrador")]
        [HttpPost]
        public async Task<ActionResult<ConcursoDto>> Adicionar(ConcursoDto concursoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _concursoService.Adicionar(_mapper.Map<Concurso>(concursoDto));

            return CustomResponse(concursoDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SorteioDto>> Atualizar(Guid id, ConcursoDto concursoDto)
        {
            if (id != concursoDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(concursoDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _concursoService.Atualizar(_mapper.Map<Concurso>(concursoDto));

            return CustomResponse(concursoDto);
        }
    }
}
