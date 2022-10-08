using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;
using JpvApi.Dominio.Modelos.Dtos;

namespace JpvApi.Servico.AutoMapper
{
    public class SystemLinqProfile : Profile
    {
        public SystemLinqProfile()
        {
            CreateMap(typeof(ListDto<>), typeof(ListaBaseDto<>)).ForMember("QuantidadeRegistros", opt => opt.Ignore());//.ForAllMembers(opt => opt.Ignore());
        }
    }
}
