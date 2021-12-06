using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Security.Cryptography
{
    /// <summary>
    /// Classe para criptografar um valor em MD5
    /// </summary>
    public class MD5Cryptography
    {
        /// <summary>
        /// Método para criptografar valores em MD5
        /// </summary>
        /// <param name="value">Valor que será criptografado</param>
        /// <returns>HASH hexadecimal resultado da criptografia</returns>
        public static string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            string result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> hexadecimal
            }

            return result;
        }
    }
}



