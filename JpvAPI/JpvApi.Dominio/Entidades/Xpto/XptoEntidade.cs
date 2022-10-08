using System;
using System.Collections.Generic;
using System.Text;
using Jpv.Dominio.Modelos.Entidade;

namespace JpvApi.Dominio.Entidades
{
    public class JpvEntidade : Entidade<JpvEntidade>
    {
        #region Variaveis
        public int SeqUsuario { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public DateTime? DtaNascimento { get; private set; }
        public decimal? ValorRenda { get; private set; }
        #endregion

        public JpvEntidade() { }

        public JpvEntidade(int seqUsuario, string cpf, string nome, DateTime? dtaNascimento, decimal? valorRenda)
        {
            SeqUsuario = seqUsuario;
            Cpf = cpf;
            Nome = nome;
            DtaNascimento = dtaNascimento;
            ValorRenda = valorRenda;

            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
