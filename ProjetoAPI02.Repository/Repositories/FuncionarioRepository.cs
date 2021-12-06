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
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependência)
        public FuncionarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public override Funcionario GetById(Guid id)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //JOIN
                .FirstOrDefault(f => f.IdFuncionario.Equals(id));
        }

        public Funcionario GetByMatricula(string matricula)
        {
            return _context.Funcionario
                .FirstOrDefault(f => f.Matricula.Equals(matricula));
        }

        public Funcionario GetByCpf(string cpf)
        {
            return _context.Funcionario
                .FirstOrDefault(f => f.Cpf.Equals(cpf));
        }

        public List<Funcionario> GetByDataAdmissao(DateTime dataMin, DateTime dataMax)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //JOIN
                .Where(f => f.DataAdmissao >= dataMin && f.DataAdmissao <= dataMax)
                .OrderBy(f => f.DataAdmissao)
                .ToList();
        }
    }
}
