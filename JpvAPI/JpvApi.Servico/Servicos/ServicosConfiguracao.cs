using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using JpvApi.Servico.Servicos.Validacoes;

namespace JpvApi.Servico.Servicos
{
    public static class ServicosConfiguracao
    {
        public static void AddServicosConfiguracao(this IServiceCollection services)
        {
            services.AddTransient<IJpvServico, JpvServico>();
            services.AddTransient<IValidacaoJpv, ValidacaoJpv>();
        }
    }
}
