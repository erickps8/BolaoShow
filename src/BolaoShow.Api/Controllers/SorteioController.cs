using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using HtmlAgilityPack;
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
        private readonly IConcursoRepository _concursoRepository;
        private readonly IMapper _mapper;

        public SorteioController(ISorteioRepository sorteioRepository, IConcursoRepository concursoRepository,
                                      IMapper mapper,
                                      ISorteioService sorteioService,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _sorteioService = sorteioService;
            _sorteioRepository = sorteioRepository;
            _concursoRepository = concursoRepository;

        }

        [AllowAnonymous]
        [HttpGet("Quina")]
        public async Task<List<int>> RetornaSorteioQuina()
        {
            var concursoVigente = _concursoRepository.ObterConcursoVigente();

            if (concursoVigente == null) return null;

            var client = new HttpClient();
            var html = await client.GetStringAsync("http://loterias.caixa.gov.br/wps/portal/loterias");
            var document = new HtmlDocument();

            document.LoadHtml(html);

            var ul = document.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("resultado-loteria quina"))
                .FirstOrDefault()
                .Descendants("li").ToList();

            var dezenas = new List<int>();

            foreach (var item in ul) 
            {
                dezenas.Add(Convert.ToInt32(item.InnerText));                
            }

            SorteioDto sorteio = new SorteioDto
            {
                Dezena_01 = dezenas[0],
                Dezena_02 = dezenas[1],
                Dezena_03 = dezenas[2],
                Dezena_04 = dezenas[3],
                Dezena_05 = dezenas[4],
                ConcursoId = concursoVigente.Id,
                Data = DateTime.Now               
            };

            var sorteiosExistentes = await ObterSorteiosPorConcurso(concursoVigente.Id);

            if (sorteiosExistentes.Any(s => sorteio.Data.Day.Equals(s.Data.Day)))
            {
                NotificarErro("Esse sorteio ja foi inserido na base de dados!");
                return null;
            }

            await Adicionar(sorteio);

            return dezenas;
        }

        [Route("{id:Guid}")]
        [HttpGet]
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
        [Route("{id:Guid}")]
        [HttpPut]
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
