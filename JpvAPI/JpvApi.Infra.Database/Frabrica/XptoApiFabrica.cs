using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tnf.Drivers.DevartPostgreSQL;
using Tnf.Runtime.Session;
using JpvApi.Infra.Contexto;

namespace JpvApi.Infra.Database.Frabrica
{
    public class JpvApiFabrica : IDesignTimeDbContextFactory<JpvContexto>
    {
        public JpvContexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JpvContexto>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            PostgreSqlLicense.Validate(connectionString);

            return new JpvContexto(builder.Options, NullTnfSession.Instance);
        }
    }
}
