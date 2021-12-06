using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoAPI02.Security.Authentication;
using ProjetoAPI02.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Configurations
{
    /// <summary>
    /// Classe para configuração do JWT no projeto API.
    /// </summary>
    public class JwtConfiguration
    {
        //Método para configurar o JWT no projeto API
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("JwtTokenModel");
            services.Configure<JwtTokenModel>(settingsSection);

            var appSettings = settingsSection.Get<JwtTokenModel>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecurityKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new JwtTokenGenerator(appSettings));
        }
    }
}





