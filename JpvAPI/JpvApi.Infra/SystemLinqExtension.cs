using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Dto;
using JpvApi.Dominio.Modelos.Dtos;

namespace JpvApi.Infra
{
    public static class SystemLinqExtension
    {
        public async static Task<IListaBaseDto<TIDto>> RealizarConsultaAsync<T, TIDto>(this IQueryable<T> query, RequestAllDto buscarTodos)
        {
            var listaDto = await query.ToListDtoAsync<T, TIDto>(buscarTodos);

            var listaBaseDto = listaDto.MapTo<ListaBaseDto<TIDto>>();

            listaBaseDto.QuantidadeRegistros = query.Count();
            return listaBaseDto;
        }

        public static IListaBaseDto<TIDto> RealizarConsulta<T, TIDto>(this IQueryable<T> query, RequestAllDto buscarTodos)
        {
            var listaDto = query.ToListDto<T, TIDto>(buscarTodos);

            var listaBaseDto = listaDto.MapTo<ListaBaseDto<TIDto>>();

            listaBaseDto.QuantidadeRegistros = query.Count();
            return listaBaseDto;
        }
    }
}
