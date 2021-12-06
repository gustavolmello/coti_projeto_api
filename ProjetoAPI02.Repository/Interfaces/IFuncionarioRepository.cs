using ProjetoAPI02.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Interfaces
{
    /// <summary>
    /// Interface de repositório para Funcionario
    /// </summary>
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByMatricula(string matricula);
        Funcionario GetByCpf(string cpf);

        List<Funcionario> GetByDataAdmissao(DateTime dataMin, DateTime dataMax);
    }
}
