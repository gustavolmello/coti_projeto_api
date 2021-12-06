using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Entities;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Repositories
{
    /// <summary>
    /// Classe de repositorio para operações com Empresa
    /// </summary>
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependência)
        public EmpresaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Empresa GetByRazaoSocial(string razaoSocial)
        {
            return _context.Empresa
                .FirstOrDefault(e => e.RazaoSocial.Equals(razaoSocial));
        }

        public Empresa GetByCnpj(string cnpj)
        {
            return _context.Empresa
                .FirstOrDefault(e => e.Cnpj.Equals(cnpj));
        }

        public int CountFuncionarios(Guid idEmpresa)
        {
            return _context.Funcionario
                .Count(f => f.IdEmpresa.Equals(idEmpresa));
        }
    }
}
