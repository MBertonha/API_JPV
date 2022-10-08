using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using JpvApi.Dominio.Dto;
using JpvApi.Dominio.Entidades;

namespace JpvApi.Servico.AutoMapper
{
    public class JpvProfile : Profile
    {
        public JpvProfile()
        {

            #region Dominio -> DTO
            CreateMap<JpvEntidade, JpvDto>();
            CreateMap<JpvEntidade, BuscarTodosJpvDto>();
            CreateMap<JpvEntidade, AdicionarJpvDto>();
            CreateMap<JpvEntidade, AtualizarJpvDto>();
            #endregion

            #region DTO -> Dominio
            CreateMap<JpvDto, JpvEntidade>();
            CreateMap<BuscarTodosJpvDto, JpvEntidade>();
            CreateMap<AdicionarJpvDto, JpvEntidade>();
            CreateMap<AtualizarJpvDto, JpvEntidade>();
            #endregion
        }

    }
}
