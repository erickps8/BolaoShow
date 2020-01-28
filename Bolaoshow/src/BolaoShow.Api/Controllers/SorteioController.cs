using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BolaoShow.Api.Dtos;
using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BolaoShow.Api.Teste;

namespace BolaoShow.Api.Controllers
{
    //[Authorize]
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
                                      INotificador notificador, IUser user) : base(notificador, user)
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

        #region Teste
        //[HttpGet("teste-sorteio")]
        //public ActionResult TesteSorteio()
        //{
        //    var calcularImposto = new CalcularImposto();
        //    calcularImposto.Executar(new ICMSImposto(), new NotaFiscal {Valor = 10M });
        //    calcularImposto.Executar(new ISSImposto(), new NotaFiscal {Valor = 14M });

        //    var sorteio = new Sorteio
        //    {
        //        Dezena_01 = 1,
        //        Dezena_02 = 45,
        //        Dezena_03 = 34,
        //        Dezena_04 = 10,
        //        Dezena_05 =67,
        //    };

        //    var listSorteio = new List<Sorteio>
        //    {
        //         new Sorteio { Dezena_01 = 1,Dezena_02 = 25,Dezena_03 = 34,Dezena_04 = 12,Dezena_05 = 58 },
        //         new Sorteio { Dezena_01 = 5, Dezena_02 = 35,Dezena_03 = 44,Dezena_04 = 12,Dezena_05 = 8 },
        //         new Sorteio { Dezena_01 = 9, Dezena_02 = 55,Dezena_03 = 42,Dezena_04 = 13,Dezena_05 = 7 },
        //    };

        //    var numSorteadosList = new List<Sorteio>();
        //    Sorteio numeroSorteado = null ;

        //    foreach (var item in listSorteio)
        //    {
        //        if (ConsultarNumeroSorteadoDezena_01(sorteio, item, ref numeroSorteado) != null)
        //        {
        //            if (!numSorteadosList.Any(x => x.Equals(numeroSorteado)))
        //                numSorteadosList.Add(numeroSorteado);
        //        }

        //        if (ConsultarNumeroSorteadoDezena_02(sorteio, item, ref numeroSorteado) != null)
        //        {
        //            if (!numSorteadosList.Any(x => x.Equals(numeroSorteado)))
        //                numSorteadosList.Add(numeroSorteado);
        //        }

        //        if (ConsultarNumeroSorteadoDezena_03(sorteio, item, ref numeroSorteado) != null)
        //        {
        //            if (!numSorteadosList.Any(x => x.Equals(numeroSorteado)))
        //                numSorteadosList.Add(numeroSorteado);
        //        }

        //        if (ConsultarNumeroSorteadoDezena_04(sorteio, item, ref numeroSorteado) != null)
        //        {
        //            if (!numSorteadosList.Any(x => x.Equals(numeroSorteado)))
        //                numSorteadosList.Add(numeroSorteado);
        //        }

        //        if (ConsultarNumeroSorteadoDezena_05(sorteio, item, ref numeroSorteado) != null)
        //        {
        //            if (!numSorteadosList.Any(x => x.Equals(numeroSorteado)))
        //                numSorteadosList.Add(numeroSorteado);
        //        }

        //    }

        //    return Ok(numeroSorteado);
        //}

        //private Sorteio ConsultarNumeroSorteadoDezena_01(Sorteio sorteioOriginal, Sorteio sorteioGerado, ref Sorteio? numeroSorteado)
        //{

        //    if (sorteioOriginal.Dezena_01.Equals(sorteioGerado.Dezena_01))
        //        CriarInstancia(ref  numeroSorteado, sorteioOriginal.Dezena_01, "1");
        //    if (sorteioOriginal.Dezena_01.Equals(sorteioGerado.Dezena_02))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "2");
        //    if (sorteioOriginal.Dezena_01.Equals(sorteioGerado.Dezena_03))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_03, "3");
        //    if (sorteioOriginal.Dezena_01.Equals(sorteioGerado.Dezena_04))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "4");
        //    if (sorteioOriginal.Dezena_01.Equals(sorteioGerado.Dezena_05))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "5");


        //    return numeroSorteado;
        //}

        //private void CriarInstancia(ref Sorteio?  numeroSorteado, int valorSorteado, string posicaoDezena)
        //{
        //    if (numeroSorteado == null)
        //        numeroSorteado = new Sorteio();

        //    switch (posicaoDezena)
        //    {
        //        case "1": numeroSorteado.Dezena_01 = valorSorteado;
        //            break;
        //        case "2":
        //            numeroSorteado.Dezena_02 = valorSorteado;
        //            break;
        //        case "3":
        //            numeroSorteado.Dezena_03 = valorSorteado;
        //            break;
        //        case "4":
        //            numeroSorteado.Dezena_04 = valorSorteado;
        //            break;
        //        case "5":
        //            numeroSorteado.Dezena_05 = valorSorteado;
        //            break;

        //    }

        //}

        //private Sorteio ConsultarNumeroSorteadoDezena_02(Sorteio sorteioOriginal, Sorteio sorteioGerado, ref Sorteio?  numeroSorteado)
        //{
        //    if (sorteioOriginal.Dezena_02.Equals(sorteioGerado.Dezena_01))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "1");
        //    if (sorteioOriginal.Dezena_02.Equals(sorteioGerado.Dezena_02))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "2");
        //    if (sorteioOriginal.Dezena_02.Equals(sorteioGerado.Dezena_03))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_03, "3");
        //    if (sorteioOriginal.Dezena_02.Equals(sorteioGerado.Dezena_04))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "4");
        //    if (sorteioOriginal.Dezena_02.Equals(sorteioGerado.Dezena_05))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "5");



        //    return numeroSorteado;
        //}

        //private Sorteio ConsultarNumeroSorteadoDezena_03(Sorteio sorteioOriginal, Sorteio sorteioGerado, ref Sorteio?  numeroSorteado)
        //{
        //    if (sorteioOriginal.Dezena_03.Equals(sorteioGerado.Dezena_01))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_01, "1");
        //    if (sorteioOriginal.Dezena_03.Equals(sorteioGerado.Dezena_02))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "2");
        //    if (sorteioOriginal.Dezena_03.Equals(sorteioGerado.Dezena_03))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_03, "3");
        //    if (sorteioOriginal.Dezena_03.Equals(sorteioGerado.Dezena_04))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "4");
        //    if (sorteioOriginal.Dezena_03.Equals(sorteioGerado.Dezena_05))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "5");



        //    return numeroSorteado;
        //}


        //private Sorteio ConsultarNumeroSorteadoDezena_04(Sorteio sorteioOriginal, Sorteio sorteioGerado, ref Sorteio?  numeroSorteado)
        //{

        //    if (sorteioOriginal.Dezena_04.Equals(sorteioGerado.Dezena_01))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "1");
        //    if (sorteioOriginal.Dezena_04.Equals(sorteioGerado.Dezena_02))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "2");
        //    if (sorteioOriginal.Dezena_04.Equals(sorteioGerado.Dezena_03))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_03, "3");
        //    if (sorteioOriginal.Dezena_04.Equals(sorteioGerado.Dezena_04))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "4");
        //    if (sorteioOriginal.Dezena_04.Equals(sorteioGerado.Dezena_05))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "5");



        //    return numeroSorteado;
        //}

        //private Sorteio ConsultarNumeroSorteadoDezena_05(Sorteio sorteioOriginal, Sorteio sorteioGerado, ref Sorteio?  numeroSorteado)
        //{

        //    if (sorteioOriginal.Dezena_05.Equals(sorteioGerado.Dezena_01))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "1");
        //    if (sorteioOriginal.Dezena_05.Equals(sorteioGerado.Dezena_02))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_02, "2");
        //    if (sorteioOriginal.Dezena_05.Equals(sorteioGerado.Dezena_03))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_03, "3");
        //    if (sorteioOriginal.Dezena_05.Equals(sorteioGerado.Dezena_04))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_04, "4");
        //    if (sorteioOriginal.Dezena_05.Equals(sorteioGerado.Dezena_05))
        //        CriarInstancia(ref numeroSorteado, sorteioOriginal.Dezena_05, "5");




        //    return numeroSorteado;
        //}
        #endregion
    }
}
