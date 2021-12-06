using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Classe de modelo de dados para edição de funcionário
    /// </summary>
    public class FuncionarioPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public Guid IdFuncionario { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da empresa do funcionário.")]
        public Guid IdEmpresa { get; set; }
    }
}
