﻿using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AddEfCorePostgrees(this IServiceCollection services)
        {
            services.AddEfCore();

            services.AddTnfDbContext<JpvContexto, PostgreesContexto>(config =>
            {
                config.DbContextOptions.UseNpgsql(config.ConnectionString);
            });

            return services;
        }
    }
}