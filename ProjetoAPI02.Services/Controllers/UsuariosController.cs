using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Repository.Entities;
using ProjetoAPI02.Repository.Interfaces;
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
    public class UsuariosController : ControllerBase
    {
        //atributo
        private readonly IUsuarioRepository _usuarioRepository;

        //método construtor para inicializar o atributo (injeção de dependência)
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(UsuarioPostModel model)
        {
            try
            {
                //verificar se o usuário já está cadastrado no banco de dados
                if (_usuarioRepository.Get(model.Email) != null)
                {
                    //HTTP 400 -> BAD REQUEST (Requisição inválida)
                    return StatusCode(400, new { mensagem = $"O email '{model.Email}' já está cadastrado, tente outro." });
                }

                //capturando os dados do usuário
                var usuario = new Usuario();

                usuario.IdUsuario = Guid.NewGuid();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senha = MD5Cryptography.Encrypt(model.Senha);
                usuario.DataCadastro = DateTime.Now;

                //cadastrar o usuário na base de dados
                _usuarioRepository.Create(usuario);

                return Ok(new { mensagem = $"Usuário '{usuario.Nome}', cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



