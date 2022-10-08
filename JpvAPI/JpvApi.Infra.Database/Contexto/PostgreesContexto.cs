using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Runtime.Session;
using JpvApi.Infra.Contexto;

namespace JpvApi.Infra.Database.Contexto
{
    public class PostgreesContexto : JpvContexto
    {
        public PostgreesContexto(DbContextOptions<JpvContexto> options, ITnfSession session) : base(options, session)
        {
        }
    }
}
