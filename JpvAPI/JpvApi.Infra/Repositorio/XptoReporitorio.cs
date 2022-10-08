using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;
using JpvApi.Dominio.Entidades;
using JpvApi.Dominio.Entidades.Repositorio;
using JpvApi.Infra.Contexto;

namespace JpvApi.Infra.Repositorio
{
    public class JpvReporitorio : EfCoreRepositoryBase<JpvContexto, JpvEntidade>, IJpvRepositorio
    {
        public JpvReporitorio(IDbContextProvider<JpvContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task RemoverExemplo(int id)
        {
            await DeleteAsync(e => e.SeqUsuario == id);
        }
    }
}
