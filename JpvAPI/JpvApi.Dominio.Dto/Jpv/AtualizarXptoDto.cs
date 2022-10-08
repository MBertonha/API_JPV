using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Tnf.Dto;

namespace JpvApi.Dominio.Dto
{
    public class AtualizarJpvDto : BaseDto
    {
        [JsonIgnore]
        public int SeqUsuario { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DtaNascimento { get; set; }
        public decimal? ValorRenda { get; set; }
    }
}
