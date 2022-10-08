using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace JpvApi.Dominio.Dto
{
    public class AdicionarJpvDto : BaseDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DtaNascimento { get; set; }
        public decimal? ValorRenda { get; set; }
    }
}
