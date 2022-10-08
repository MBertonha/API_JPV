using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using JpvApi.Dominio.Entidades;
using static JpvApi.Infra.Contexto.JpvContexto;

namespace JpvApi.Infra.Mapeamento
{
    public class JpvMap : IEntityTypeConfiguration<JpvEntidade>
    {
        public void Configure(EntityTypeBuilder<JpvEntidade> builder)
        {
            builder.HasKey(e => new { e.SeqUsuario });

            builder.Property(e => e.SeqUsuario)
               .HasColumnName("seq_usuario")
               .ValueGeneratedOnAdd()
               .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_usuario"));


            builder.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("cpfcliente");

            builder.Property(e => e.Nome)
                .HasMaxLength(30)
                .HasColumnName("nomecliente");

            builder.Property(e => e.DtaNascimento)
                .HasColumnName("datanasc");

            builder.Property(e => e.ValorRenda)
                .HasColumnName("valorrenda");

            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_usuario");
        }
    }
}
