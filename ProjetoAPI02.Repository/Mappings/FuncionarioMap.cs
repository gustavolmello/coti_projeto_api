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
    /// Classe de mapeamento ORM para Funcionario
    /// </summary>
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        //método para mapeamento da entidade
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("FUNCIONARIO");

            //chave primária
            builder.HasKey(f => f.IdFuncionario);

            //demais campos da tabela
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            #region Mapeamento dos campos unicos (UNIQUE)

            builder.HasIndex(f => f.Matricula).IsUnique();
            builder.HasIndex(f => f.Cpf).IsUnique();

            #endregion

            #region Mapeamento dos relacionamentos (FOREIGN KEY)

            builder.HasOne(f => f.Empresa) //Funcionário PERTENCE A 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa POSSUI Muitos Funcionários
                .HasForeignKey(f => f.IdEmpresa); //chave estrangeira do relacionamento

            #endregion
        }
    }
}
