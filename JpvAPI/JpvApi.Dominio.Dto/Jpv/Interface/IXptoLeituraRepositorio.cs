using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JpvApi.Dominio.Modelos.Dtos;

namespace JpvApi.Dominio.Dto.Interface
{
    public interface IJpvLeituraRepositorio
    {
        Task<IListaBaseDto<JpvDto>> BuscarTodos(BuscarTodosJpvDto buscarTodos);

        Task<JpvDto> BuscarPorId(int seaOs);
    }
}
