using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Entities
{
    /// <summary>
    /// Classe de entidade para Funcionario
    /// </summary>
    public class Funcionario
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Guid IdEmpresa { get; set; }

        #region Relacionamentos

        public Empresa Empresa { get; set; }

        #endregion
    }
}
