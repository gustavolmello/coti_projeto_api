using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Repository.Entities;
using ProjetoAPI02.Repository.Interfaces;
using ProjetoAPI02.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Controllers
{
    [Authorize] //Só permitir acesso de usuários autenticados
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //atributo
        private readonly IEmpresaRepository _empresaRepository;
        
        //construtor para inicialização do atributo (injeção de dependência)
        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        [HttpPost]
        public IActionResult Post(EmpresaPostModel model)
        {
            try
            {
                //verificar se ja existe uma empresa cadastrada com a razao social informada
                if (_empresaRepository.GetByRazaoSocial(model.RazaoSocial) != null)
                    return StatusCode(400, new { mensagem = $"A Razão Social '{model.RazaoSocial}' já está cadastrado, tente outro" });

                //verificar se ja existe uma empresa cadastrada com o cnpj informado
                if (_empresaRepository.GetByCnpj(model.Cnpj) != null)
                    return StatusCode(400, new { mensagem = $"O CNPJ '{model.Cnpj}' já está cadastrado, tente outro" });

                var empresa = new Empresa();

                empresa.IdEmpresa = Guid.NewGuid();
                empresa.NomeFantasia = model.NomeFantasia;
                empresa.RazaoSocial = model.RazaoSocial;
                empresa.Cnpj = model.Cnpj;

                _empresaRepository.Create(empresa);

                return Ok(new { mensagem = $"Empresa '{empresa.NomeFantasia}' cadastrado com sucesso." });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutModel model)
        {
            try
            {
                //buscar no banco de dados a empresa atraves do ID..
                var empresa = _empresaRepository.GetById(model.IdEmpresa);

                //verificar se a empresa foi encontrada
                if(empresa != null)
                {
                    //atualizando os dados da empresa no banco de dados
                    empresa.NomeFantasia = model.NomeFantasia;
                    _empresaRepository.Update(empresa);

                    return StatusCode(200, new { mensagem = $"Empresa '{empresa.NomeFantasia}' atualizada com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Empresa não encontrada, ID inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //buscar os dados da empresa no banco atraves do id..
                var empresa = _empresaRepository.GetById(id);

                //verificar se a empresa foi encontrada
                if(empresa != null)
                {
                    //verificar se a empresa possui funcionários
                    if(_empresaRepository.CountFuncionarios(id) > 0)
                        return StatusCode(400, new { mensagem = "A Empresa não pode ser excluída pois possui funcionários." });

                    //excluindo a empresa
                    _empresaRepository.Delete(empresa);

                    return StatusCode(200, new { mensagem = $"Empresa '{empresa.NomeFantasia}' excluída com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Empresa não encontrada, ID inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<EmpresaGetModel>();

                //percorrer todas as empresas do banco de dados
                foreach (var item in _empresaRepository.GetAll())
                {
                    var model = new EmpresaGetModel();

                    model.IdEmpresa = item.IdEmpresa;
                    model.NomeFantasia = item.NomeFantasia;
                    model.RazaoSocial = item.RazaoSocial;
                    model.Cnpj = item.Cnpj;
                    model.QuantidadeFuncionarios = _empresaRepository.CountFuncionarios(item.IdEmpresa);

                    lista.Add(model);
                }

                return StatusCode(200, lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //buscar os dados da empresa atraves do id..
                var empresa = _empresaRepository.GetById(id);

                //verificando se a empresa foi encontrada
                if(empresa != null)
                {
                    var model = new EmpresaGetModel();

                    model.IdEmpresa = empresa.IdEmpresa;
                    model.NomeFantasia = empresa.NomeFantasia;
                    model.RazaoSocial = empresa.RazaoSocial;
                    model.Cnpj = empresa.Cnpj;
                    model.QuantidadeFuncionarios = _empresaRepository.CountFuncionarios(empresa.IdEmpresa);

                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Empresa não encontrada, ID inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}
