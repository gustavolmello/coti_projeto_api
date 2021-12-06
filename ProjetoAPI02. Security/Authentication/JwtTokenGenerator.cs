using Microsoft.IdentityModel.Tokens;
using ProjetoAPI02.Security.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Security.Authentication
{
    /// <summary>
    /// Classe para realizar a geração do TOKEN dos usuarios da API
    /// </summary>
    public class JwtTokenGenerator
    {
        //atributo
        private readonly JwtTokenModel _jwtTokenModel;

        //construtor para injeção de dependência
        public JwtTokenGenerator(JwtTokenModel jwtTokenModel)
        {
            _jwtTokenModel = jwtTokenModel;
        }

        //método para fazer a geração do TOKEN
        public string Create(string userEmail)
        {
            //utilizando a chave secreta para criptografar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenModel.SecurityKey);

            //criando o conteudo do TOKEN
            var tokenDescription = new SecurityTokenDescriptor
            {
                //criando a identificação do usuario para o AspNet
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail) //nome do usuario
                }),

                //definindo a data de expiração do Token
                Expires = DateTime.Now.AddHours(_jwtTokenModel.ExpirationInHours),

                //criptografia do Token a chave secreta (evitar falsificação)
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //retornando o TOKEN
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}





