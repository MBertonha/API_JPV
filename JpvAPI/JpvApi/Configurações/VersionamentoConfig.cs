using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JpvApi.Configurações
{
    public static class VersionamentoConfiguracao
    {
        public static void AddVersionamentoConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;

            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
        }

        public static void UseVersionamentoConfiguration(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseMvc()
               .UseApiVersioning()
               .UseMvcWithDefaultRoute();
        }
    }
}
