using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Repository.Entities;
using ProjetoAPI02.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Contexts
{
    /// <summary>
    /// Classe padrão do EF para conexão com o banco de dados
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor para inicializar a classe (injeção de dependência)
        public SqlServerContext(DbContextOptions<SqlServerContext> context) : base(context)
        {
            //método para receber os parametros de conexão com o banco
        }

        //declarar uma propridade DbSet para cada classe de entidade
        //eles irão permitir que façamos as operações de CRUD para cada entidade
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //método para adicionar cada mapeamento de entidade (ORM)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}

