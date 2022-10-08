using Modelo.Servico.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Application.Services;
using Tnf.Notifications;
using Tnf.Repositories.Uow;
using Jpv.Dominio.Modelos.Entidade;

namespace Modelo.Servico.Modelos
{
    public abstract class ServicoBase<T> : ApplicationService where T : Entidade<T>
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkCompleteHandle _controleTransacao;

        public ServicoBase(INotificationHandler controleNotificacao,
            IUnitOfWorkManager controleTransacao) : base(controleNotificacao)
        {
            _controleNotificacao = controleNotificacao;
            //_controleTransacao = controleTransacao.Begin();
        }

        /// <summary>
        /// Retorna <b>true</b> se há inconsistência, <b>false</b> se não há
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected abstract Task<bool> VerificaInconsistencias(T obj, int operacao);
        protected virtual bool EstaValido(Entidade<T> obj)
        {
            if (obj.EstaValido()) return true;

            NotificarErros(obj);

            return false;
        }

        protected async Task<bool> Commit()
        {
            if (_controleNotificacao.HasNotification()) return false;

            //await _controleTransacao.CompleteAsync();
            return true;
        }

        private void NotificarErros(Entidade<T> obj)
        {
            foreach (var error in obj.ResultadoValidacao.Errors)
            {
                Notificacao.AdicionarNotificacao(_controleNotificacao, error.ErrorMessage);
            }
        }
    }
}
