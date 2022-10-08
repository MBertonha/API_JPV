using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JpvApi.Dominio.Dto;
using JpvApi.Dominio.Modelos.Dtos;

namespace JpvApi.Servico.Servicos
{
    public interface IJpvServico
    {
        Task<IListaBaseDto<JpvDto>> BuscarTodos(BuscarTodosJpvDto model);
        Task<JpvDto> Adicionar(AdicionarJpvDto model);
        Task<AtualizarJpvDto> Atualizar(int idOs, AtualizarJpvDto model);
        Task<bool> Remover(int id);
    }
}
