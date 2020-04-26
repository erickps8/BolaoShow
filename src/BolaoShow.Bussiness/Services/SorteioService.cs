using BolaoShow.Bussiness.Interfaces;
using BolaoShow.Bussiness.Models;
using BolaoShow.Bussiness.Models.Validations;
using System.Threading.Tasks;

namespace BolaoShow.Bussiness.Services
{
    public class SorteioService : BaseService, ISorteioService
    {
        private readonly ISorteioRepository _sorteioRepository;
        public SorteioService(ISorteioRepository sorteioRepository, INotificador notificador) : base(notificador)
        {
            _sorteioRepository = sorteioRepository;
        }
        public async Task<bool> Adicionar(Sorteio sorteio)
        {
            if (!ExecutarValidacao(new SorteioValidation(), sorteio)) return false;
            
            await _sorteioRepository.Adicionar(sorteio);
            return true;
        }

        public async Task<bool> Atualizar(Sorteio sorteio)
        {
            if (!ExecutarValidacao(new SorteioValidation(), sorteio)) return false;

            await _sorteioRepository.Atualizar(sorteio);
            return true;
        }
        public void Dispose()
        {
            _sorteioRepository?.Dispose();
        }

    }
}
