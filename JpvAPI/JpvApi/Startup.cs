using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tnf.Configuration;
using JpvApi.Infra.Database;
using JpvApi.Servico.Servicos;
using JpvApi.Servico.AutoMapper;
using JpvApi.Dominio.Localizacao;
using JpvApi.Configurações;

namespace JpvAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BancoDadosConfig = new PostgreesConfig(configuration);
        }

        public IConfiguration Configuration { get; }
        public PostgreesConfig BancoDadosConfig { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson();

            #region CORS
            services.AddCors();
            #endregion

            #region Versionamento
            services.AddVersionamentoConfiguration();
            #endregion

            #region Banco Dados
            services.AddEfCorePostgrees();
            #endregion

            #region Memory Cache
            services.AddMemoryCache();
            #endregion

            #region Classes
            services.AddServicosConfiguracao();
            #endregion

            #region TNF
            services.AddAutoMapperTnf();
            services.AddTnfEntityFrameworkCore();
            services.AddTnfDomain();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguration(Configuration);
            #endregion

            return services.BuildServiceProvider(false);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger
            app.UseSwaggerConfiguration(provider);
            #endregion

            #region TNF
            app.UseTnfAspNetCore(configuration =>
            {
                configuration.UseDomainLocalization();
                configuration.DefaultNameOrConnectionString = "Server=localhost;Port=5432;Database=desafio;User Id=postgres;Password=postgres;";
                configuration.EnableDevartPostgreSQLDriver();
                configuration.DefaultPageSize(10, 999999);
            });
            #endregion

            #region CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            #endregion

            app.UseMvc();
        }
    }
}
