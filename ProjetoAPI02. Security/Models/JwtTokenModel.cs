using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Security.Models
{
    /// <summary>
    /// Classe de modelo de dados para a geração do TOKEN
    /// </summary>
    public class JwtTokenModel
    {
        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public int ExpirationInHours { get; set; }

        /// <summary>
        /// Chave de segurança para criptografia do TOKEN
        /// (anti-falsificação)
        /// </summary>
        public string SecurityKey { get; set; }
    }
}



