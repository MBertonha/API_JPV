using Modelo.Servico.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tnf.Notifications;
using Tnf.Repositories.Uow;
using JpvApi.Dominio.Dto;
using JpvApi.Dominio.Dto.Interface;
using JpvApi.Dominio.Entidades;
using JpvApi.Dominio.Entidades.Repositorio;
using JpvApi.Dominio.Modelos.Dtos;
using JpvApi.Servico.Servicos.Validacoes;
using JpvApi.Servico.Utilitarios;

namespace JpvApi.Servico.Servicos
{
    public class JpvServico : ServicoBase<JpvEntidade>, IJpvServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IJpvRepositorio _Repositorio;
        private readonly IJpvLeituraRepositorio _LeituraRepositorio;
        private readonly IValidacaoJpv _Validacao;

        public JpvServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IJpvRepositorio repositorio,
           IJpvLeituraRepositorio leituraRepositorio,
           IValidacaoJpv validacao
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
            _Validacao = validacao;
        }

        public async Task<JpvDto> Adicionar(AdicionarJpvDto model)
        {
            try
            {
                if (!ValidateDto<JpvDto>(model)) return null;

                if(model.ValorRenda.HasValue) model.ValorRenda = decimal.Round((decimal)model.ValorRenda, 2);
                var novoObj = model.MapTo<JpvEntidade>();

                model.ValorRenda = Math.Round((decimal)model.ValorRenda, 2);
                
                var existeInconsitencia = await VerificaInconsistencias(novoObj, 1);
                

                if (!existeInconsitencia && EstaValido(novoObj))
                {
                    novoObj = await _Repositorio.InsertAsync(novoObj);
                    if (await Commit())
                    {
                        return novoObj.MapTo<JpvDto>();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<AtualizarJpvDto> Atualizar(int idOs, AtualizarJpvDto model)
        {
            try
            {
                if (!ValidateDto(model)) return null;

                var obj = await _LeituraRepositorio.BuscarPorId(idOs);

                var novoModel = new AtualizarJpvDto()
                {
                    SeqUsuario = obj.SeqUsuario,
                    Cpf = model.Cpf.IsNullOrEmpty() ? obj.Cpf : model.Cpf,
                    Nome = model.Nome.IsNullOrEmpty() ? obj.Nome : model.Nome,
                    DtaNascimento = model.DtaNascimento.ToString().IsNullOrEmpty() ? obj.DtaNascimento : model.DtaNascimento,
                    ValorRenda = model.ValorRenda.ToString().IsNullOrEmpty() ? obj.ValorRenda : model.ValorRenda,

                };

                novoModel.ValorRenda = Math.Round((decimal)novoModel.ValorRenda, 2);

                var novo = novoModel.MapTo<JpvEntidade>();
                var existeInconsitencia = await VerificaInconsistencias(novo, 2);

                if (!existeInconsitencia && EstaValido(novo))
                {
                    novo = await _Repositorio.UpdateAsync(novo);

                    return novoModel;
                }

                return null;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<IListaBaseDto<JpvDto>> BuscarTodos(BuscarTodosJpvDto model)
        {
            try
            {
                return await _LeituraRepositorio.BuscarTodos(model);
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.Message.ToString());
                return null;
            }
        }

        public async Task<bool> Remover(int seqOs)
        {
            var obj = await _LeituraRepositorio.BuscarPorId(seqOs);
            if (obj == null)
            {
                return false;
            }

            await _Repositorio.RemoverExemplo(seqOs);

            return true;
        }

        protected override async Task<bool> VerificaInconsistencias(JpvEntidade obj, int operacao)
        {
            var cpfValido = await _Validacao.ValidaCpf(obj.Cpf, operacao);
            var dtaValida = await _Validacao.ValidacaoData(obj.DtaNascimento, operacao);
            var vlrValido = await _Validacao.ValidacaoValor(obj.ValorRenda, operacao);
            var nomePrestValido = await _Validacao.ValidacaoNome(obj.Nome, operacao);

            return cpfValido || dtaValida || vlrValido || nomePrestValido;
        }
    }
}
