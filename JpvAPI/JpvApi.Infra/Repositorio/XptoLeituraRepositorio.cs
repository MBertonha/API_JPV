using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;
using JpvApi.Dominio.Dto;
using JpvApi.Dominio.Dto.Interface;
using JpvApi.Dominio.Entidades;
using JpvApi.Dominio.Modelos.Dtos;
using JpvApi.Infra.Contexto;

namespace JpvApi.Infra.Repositorio
{
    public class JpvLeituraRepositorio : EfCoreRepositoryBase<JpvContexto, JpvEntidade>, IJpvLeituraRepositorio
    {
        public JpvLeituraRepositorio(IDbContextProvider<JpvContexto> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<JpvDto> BuscarPorId(int seqOs)
        {
            var dtoRtorno = await GetAll((e) => e.SeqUsuario == seqOs).FirstOrDefaultAsync();
            return dtoRtorno.MapTo<JpvDto>();
        }

        public async Task<IListaBaseDto<JpvDto>> BuscarTodos(BuscarTodosJpvDto model)
        {
            var query = Table
               .OrderByDescending(x => x.SeqUsuario)
               .AsQueryable();

            if (!model.Filter.IsNullOrEmpty())
            {
                query = query.Where(e =>
                    (EF.Functions.Like(e.SeqUsuario.ToString(), $"%{model.SeqUsuario}%") ||
                    EF.Functions.Like(e.Cpf.ToUpper(), $"%{model.Cpf.ToUpper()}%") ||
                    EF.Functions.Like(e.Nome.ToUpper(), $"%{model.Nome.ToUpper()}%") ||
                    EF.Functions.Like(e.DtaNascimento.ToString(), $"%{model.DtaNascimento.ToString()}%") ||
                    EF.Functions.Like(e.ValorRenda.ToString(), $"%{model.ValorRenda}"))
                );
            }
            else
            {
                if (model.SeqUsuario != null)
                {
                    query = query.Where(e => model.SeqUsuario.Any((emp) => e.SeqUsuario == emp));
                }
                if (!model.Cpf.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Cpf.ToUpper(), $"%{model.Cpf.ToUpper()}%"));
                }
                if (!model.Nome.IsNullOrEmpty())
                {
                    query = query.Where(e => EF.Functions.Like(e.Nome.ToUpper(), $"%{model.Nome.ToUpper()}%"));
                }
                if (model.DtaNascimento != null)
                {
                    query = query.Where(e => EF.Functions.Like(e.DtaNascimento.ToString(), $"%{model.DtaNascimento.ToString()}%"));
                }
                if (model.ValorRenda.HasValue)
                {
                    query = query.Where(e => EF.Functions.Like(e.ValorRenda.ToString(), $"%{model.ValorRenda}%"));
                }
            }

            return await query.RealizarConsultaAsync<JpvEntidade, JpvDto>(model);
        }
    }
}
