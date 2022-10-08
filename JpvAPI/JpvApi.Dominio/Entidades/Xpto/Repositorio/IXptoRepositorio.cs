using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace JpvApi.Dominio.Entidades.Repositorio
{
    public interface IJpvRepositorio : IRepository
    {
        Task<JpvEntidade> InsertAsync(JpvEntidade exemplo);
        Task<JpvEntidade> UpdateAsync(JpvEntidade exemplo);
        Task RemoverExemplo(int id);
    }
}
