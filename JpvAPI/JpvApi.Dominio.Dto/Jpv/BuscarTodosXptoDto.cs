using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace JpvApi.Dominio.Dto
{
    public class BuscarTodosJpvDto : RequestAllDto
    {
        public int[] SeqUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal? ValorRenda { get; set; }
        public DateTime? DtaNascimento { get; set; }
        public string Filter { get; set; }
    }
}
