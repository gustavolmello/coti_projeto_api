using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de funcionário
    /// </summary>
    public class FuncionarioGetModel
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public EmpresaGetModel Empresa { get; set; }
    }
}
