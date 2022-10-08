using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace JpvApi.Dominio.Modelos.Dtos
{
    public interface IListaBaseDto<TDto> : IListDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
