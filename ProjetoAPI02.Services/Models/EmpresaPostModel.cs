using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Modelo de dados da API para cadastro de empresa
    /// </summary>
    public class EmpresaPostModel
    {
        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome fantasia da empresa.")]
        public string NomeFantasia { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a razão social da empresa.")]
        public string RazaoSocial { get; set; }

        [MinLength(15, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(25, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o cnpj da empresa.")]
        public string Cnpj { get; set; }
    }
}
