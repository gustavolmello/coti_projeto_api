using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para Empresa
    /// </summary>
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        //método para mapeamento da entidade
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela
            builder.ToTable("EMPRESA");

            //campo chave primária
            builder.HasKey(e => e.IdEmpresa);

            //mapeando os campos da tabela
            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IDEMPRESA");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(25)
                .IsRequired();

            #region Mapeamento dos campos unicos (UNIQUE)

            builder.HasIndex(e => e.RazaoSocial).IsUnique();
            builder.HasIndex(e => e.Cnpj).IsUnique();

            #endregion
        }
    }
}
