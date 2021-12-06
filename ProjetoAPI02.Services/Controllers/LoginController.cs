using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Repository.Interfaces;
using ProjetoAPI02.Security.Authentication;
using ProjetoAPI02.Security.Cryptography;
using ProjetoAPI02.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributos
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        //construtor para inicialização do atributo (injeção de dependência)
        public LoginController(IUsuarioRepository usuarioRepository, JwtTokenGenerator jwtTokenGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        public IActionResult Post(LoginModel model)
        {
            try
            {
                //consultar o usuario no banco de dados atraves do email e senha
                var usuario = _usuarioRepository.Get(model.Email, MD5Cryptography.Encrypt(model.Senha));

                //verificar se o usuario foi encontrado
                if (usuario != null)
                {
                    return Ok(
                        new
                        {
                            mensagem = "Usuário autenticado com sucesso",
                            nome = usuario.Nome,
                            email = usuario.Email,
                            accessToken = _jwtTokenGenerator.Create(usuario.Email)
                        }
                        );
                }
                else
                {
                    //erro de acesso não autorizado (401 - UNAUTHORIZED)
                    return StatusCode(401, new { mensagem = "Acesso negado, usuário inválido." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



