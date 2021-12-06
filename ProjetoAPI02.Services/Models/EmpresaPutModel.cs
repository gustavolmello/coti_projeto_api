using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models
{
    /// <summary>
    /// Modelo de dados para edição de empresa na API.
    /// </summary>
    public class EmpresaPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid IdEmpresa { get; set; }

        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome fantasia da empresa.")]
        public string NomeFantasia { get; set; }
    }
}
