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
    /// Classe de mapeamento ORM para Usuario
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        //método para mapeamento da entidade
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("USUARIO");

            //chave primária
            builder.HasKey(u => u.IdUsuario);

            //campos da tabela
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IDUSUARIO");

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();
        }
    }
}
