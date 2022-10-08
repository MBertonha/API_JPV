using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using JpvApi.Dominio.Dto.Interface;
using JpvApi.Dominio.Entidades.Repositorio;
using JpvApi.Infra.Repositorio;

namespace JpvApi.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            services.AddTransient<IJpvRepositorio, JpvReporitorio>();
            services.AddTransient<IJpvLeituraRepositorio, JpvLeituraRepositorio>();

            return services;
        }
    }
}
