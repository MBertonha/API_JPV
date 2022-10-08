using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JpvApi.Configurações
{
    public class PostgreesConfig
    {
        public string ConnectionString { get; set; }

        public PostgreesConfig(IConfiguration configuration)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}
