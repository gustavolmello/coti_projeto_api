using ProjetoAPI02.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Interfaces
{
    /// <summary>
    /// Interface de repositorio para Empresa
    /// </summary>
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        Empresa GetByRazaoSocial(string razaoSocial);
        Empresa GetByCnpj(string cnpj);

        int CountFuncionarios(Guid idEmpresa);
    }
}
