using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Models.Validations;
using System;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class ApostaService : BaseService, IApostaService
    {
        private readonly IApostaRepository _apostaRepository;
        private readonly IValidaApostasService _validaApostaService;
        private readonly IUser _user;
        public ApostaService(IApostaRepository apostaRepository, IValidaApostasService validaApostaService, INotificador notificador, IUser user) : base(notificador)
        {
            _apostaRepository = apostaRepository;
            _validaApostaService = validaApostaService;
            _user = user;
        }
        public async Task<bool> Adicionar(Aposta aposta)
        {
            aposta.Data = DateTime.Now;
            aposta.UserId = _user.GetUserId();
            aposta.ConcursoId = _validaApostaService.ConcursoVigente().Id;

            if (!ExecutarValidacao(new ApostaValidation(), aposta)) return false;
            
            await _apostaRepository.Adicionar(aposta);
            return true;
        }

        public async Task<bool> Atualizar(Aposta aposta)
        {
            if (!ExecutarValidacao(new ApostaValidation(), aposta)) return false;

            await _apostaRepository.Atualizar(aposta);
            return true;
        }

        public void Dispose()
        {
            _apostaRepository?.Dispose();
        }
    }
}
