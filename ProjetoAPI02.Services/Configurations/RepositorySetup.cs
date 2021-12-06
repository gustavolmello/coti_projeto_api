using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using ProjetoAPI02.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Configurations
{
    public class RepositorySetup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //capturar a string de conexão mapeada no arquivo /appsettings.json
            var connectionstring = configuration.GetConnectionString("Projeto");

            //configurar a classe SqlServerContext
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionstring));

            //configurar cada interface / classe do repositorio
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
