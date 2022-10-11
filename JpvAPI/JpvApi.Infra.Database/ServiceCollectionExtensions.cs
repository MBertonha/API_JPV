using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using JpvApi.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using JpvApi.Infra.Database.Contexto;

namespace JpvApi.Infra.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCoreSqlServer(this IServiceCollection services, string conString)
        {
            services.AddEfCore();

            services.AddTnfDbContext<JpvContexto, SqlServerContexto>(config =>
            {
                config.DbContextOptions.UseSqlServer(conString);
            });

            return services;
        }
    }
}
