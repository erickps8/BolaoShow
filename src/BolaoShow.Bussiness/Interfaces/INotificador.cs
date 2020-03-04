using BolaoShow.Bussiness.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoShow.Bussiness.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
