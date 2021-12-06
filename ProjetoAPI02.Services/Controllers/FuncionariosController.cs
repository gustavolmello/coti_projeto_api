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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        //atributos
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEmpresaRepository _empresaRepository;

        //construtor para inicialização dos atributos (injeção de dependência)
        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IEmpresaRepository empresaRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioPostModel model)
        {
            try
            {
                //verificar se o CPF informado já está cadastrado
                if(_funcionarioRepository.GetByCpf(model.Cpf) != null)
                    return StatusCode(400, new { mensagem = $"O CPF '{model.Cpf}' já está cadastrado, tente outro" });

                //verificar se a Matrícula informada já está cadastrado
                if (_funcionarioRepository.GetByMatricula(model.Matricula) != null)
                    return StatusCode(400, new { mensagem = $"A Matrícula '{model.Matricula}' já está cadastrada, tente outro" });

                //verificar se a Empresa informada não existe na base de dados
                if(_empresaRepository.GetById(model.IdEmpresa) == null)
                    return StatusCode(400, new { mensagem = $"A Empresa '{model.IdEmpresa}' não foi encontrada, ID inválido." });

                var funcionario = new Funcionario();

                funcionario.IdFuncionario = Guid.NewGuid();
                funcionario.Nome = model.Nome;
                funcionario.Cpf = model.Cpf;
                funcionario.Matricula = model.Matricula;
                funcionario.DataAdmissao = model.DataAdmissao;
                funcionario.IdEmpresa = model.IdEmpresa;

                _funcionarioRepository.Create(funcionario);

                return StatusCode(200, new { mensagem = $"Funcionário '{funcionario.Nome}' cadastrado com sucesso." });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioPutModel model)
        {
            try
            {
                //consultar o funcionario no banco de dados atraves do ID
                var funcionario = _funcionarioRepository.GetById(model.IdFuncionario);

                //verificar se o funcionario foi encontrado
                if(funcionario != null)
                {
                    //verificar se a Empresa informada não existe na base de dados
                    if (_empresaRepository.GetById(model.IdEmpresa) == null)
                        return StatusCode(400, new { mensagem = $"A Empresa '{model.IdEmpresa}' não foi encontrada, ID inválido." });

                    funcionario.Nome = model.Nome;
                    funcionario.DataAdmissao = model.DataAdmissao;
                    funcionario.IdEmpresa = model.IdEmpresa;

                    //atualizando os dados do funcionario
                    _funcionarioRepository.Update(funcionario);

                    return StatusCode(200, new { mensagem = $"Funcionário '{funcionario.Nome}' atualizado com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Funcionário não encontrado, ID inválido." });
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
                //obter o funcionario na base de dados atraves do ID..
                var funcionario = _funcionarioRepository.GetById(id);

                //verificar se o funcionario foi encontrado
                if(funcionario != null)
                {
                    //excluindo o funcionario
                    _funcionarioRepository.Delete(funcionario);

                    return StatusCode(200, new { mensagem = $"Funcionário '{funcionario.Nome}' excluído com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Funcionário não encontrado, ID inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{dataAdmissaoMin}/{dataAdmissaoMax}")]
        public IActionResult GetAll(DateTime dataAdmissaoMin, DateTime dataAdmissaoMax)
        {
            try
            {
                var lista = new List<FuncionarioGetModel>();

                //consultar os funcionarios no banco de dados atraves do periodo de data de admissão
                foreach (var item in _funcionarioRepository.GetByDataAdmissao(dataAdmissaoMin, dataAdmissaoMax))
                {
                    var model = new FuncionarioGetModel();

                    model.IdFuncionario = item.IdFuncionario;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Matricula = item.Matricula;
                    model.DataAdmissao = item.DataAdmissao;
                    model.Empresa = new EmpresaGetModel();

                    model.Empresa.IdEmpresa = item.Empresa.IdEmpresa;
                    model.Empresa.NomeFantasia = item.Empresa.NomeFantasia;
                    model.Empresa.RazaoSocial = item.Empresa.RazaoSocial;
                    model.Empresa.Cnpj = item.Empresa.Cnpj;
                    model.Empresa.QuantidadeFuncionarios = _empresaRepository.CountFuncionarios(item.IdEmpresa);

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
                //consultar 1 funcionario na base de dados atraves do ID
                var funcionario = _funcionarioRepository.GetById(id);

                //verificar se o funcionario foi encontrado
                if(funcionario != null)
                {
                    var model = new FuncionarioGetModel();

                    model.IdFuncionario = funcionario.IdFuncionario;
                    model.Nome = funcionario.Nome;
                    model.Cpf = funcionario.Cpf;
                    model.Matricula = funcionario.Matricula;
                    model.DataAdmissao = funcionario.DataAdmissao;
                    model.Empresa = new EmpresaGetModel();

                    model.Empresa.IdEmpresa = funcionario.Empresa.IdEmpresa;
                    model.Empresa.NomeFantasia = funcionario.Empresa.NomeFantasia;
                    model.Empresa.RazaoSocial = funcionario.Empresa.RazaoSocial;
                    model.Empresa.Cnpj = funcionario.Empresa.Cnpj;
                    model.Empresa.QuantidadeFuncionarios = _empresaRepository.CountFuncionarios(funcionario.IdEmpresa);

                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Funcionário não encontrado, ID inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}
