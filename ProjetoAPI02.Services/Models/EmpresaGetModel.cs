using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Modelo de dados para consulta de empresas na API.
    /// </summary>
    public class EmpresaGetModel
    {
        public Guid IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public int QuantidadeFuncionarios { get; set; }
    }
}
