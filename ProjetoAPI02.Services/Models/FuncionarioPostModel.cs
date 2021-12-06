using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Modelo de dados para cadastro de funcionário
    /// </summary>
    public class FuncionarioPostModel
    {
        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a matrícula do funcionário.")]
        public string Matricula { get; set; }

        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(15, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da empresa do funcionário.")]
        public Guid IdEmpresa { get; set; }
    }
}
