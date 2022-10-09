using JpvApi.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Runtime.Session;

namespace JpvApi.Infra.Database.Contexto
{
    public class SqlServerContexto : JpvContexto
    {
        public SqlServerContexto(DbContextOptions<JpvContexto> options, ITnfSession session) : base(options, session)
        {
        }
    }
}
