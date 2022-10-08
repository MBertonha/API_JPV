using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace JpvApi.Dominio.Modelos.Dtos
{
    public class ListaBaseDto<TDto> : ListDto<TDto>, IListaBaseDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
