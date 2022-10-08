using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;
using JpvApi.Dominio.Dto;
using JpvApi.Dominio.Modelos.Dtos;
using JpvApi.Servico.Servicos;

namespace JpvAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class JpvController : TnfController
    {
        private readonly IJpvServico _Servico;
        public JpvController(IJpvServico seervico)
        {
            _Servico = seervico;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IListaBaseDto<JpvDto>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosJpvDto buscarTodos)
        {
            return CreateResponseOnGetAll(await _Servico.BuscarTodos(buscarTodos));
        }

        [HttpPost]
        [ProducesResponseType(typeof(JpvDto), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AdicionarJpvDto model)
        {

            var modelDto = await _Servico.Adicionar(model);
            if (modelDto == null)
            {
                return BadRequest("Erro ao incluir usuario");
            }
            else
            {
                return CreateResponseOnPost(modelDto);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(JpvDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar([FromRoute]int id, [FromBody] AtualizarJpvDto model)
        {
            if(id <= 0)
            {
                return BadRequest("Seq do usuario é obrigatório ou está inválido");
            }

            var exemplo = await _Servico.Atualizar(id, model);
            if (exemplo == null)
            {
                return BadRequest("Erro ao atualizar usuario");
            }
            else
            {
                return CreateResponseOnPut(exemplo);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Seq do usuario obrigatório ou está inválido");
            }

            var retorno = await _Servico.Remover(id);

            if (!retorno)
            {
                return BadRequest("Seq não encontrado");
            }
            else
            {
                return Accepted("Usuário deletado com sucesso!");
            }
        }
    }
}
