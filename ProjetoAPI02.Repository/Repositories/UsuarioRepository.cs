using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Entities;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Repositories
{
    /// <summary>
    /// Classe de repositorio de dados para a entidade Usuario
    /// </summary>
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependência)
        public UsuarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Usuario Get(string email)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email)
                                  && u.Senha.Equals(senha));
        }
    }
}
