using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class ApostaService : BaseService, IApostaService
    {
        private readonly IApostaRepository _apostaRepository;
        public ApostaService(IApostaRepository apostaRepository, INotificador notificador) : base(notificador)
        {
            _apostaRepository = apostaRepository;
        }

        public async Task<bool> Adicionar(Aposta aposta)
        {
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
