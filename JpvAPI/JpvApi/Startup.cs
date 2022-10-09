using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tnf.Configuration;
using JpvApi.Infra.Database;
using JpvApi.Servico.Servicos;
using JpvApi.Servico.AutoMapper;
using JpvApi.Dominio.Localizacao;
using JpvApi.Configurações;
using JpvApi.Infra.Contexto;

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
            //services.AddEfCorePostgrees();
            services.AddEfCoreSqlServer();
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

        /*Conexão com Sql Server*/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration(provider);

            app.UseRouting();

            #region CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            #endregion

            app.UseAuthorization();

            app.UseMvc();
        }
    }
}
