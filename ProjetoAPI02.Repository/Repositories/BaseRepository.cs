using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Repositories
{
    /// <summary>
    /// Classe de repositorio generico do projeto
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa qualquer entidade do projeto</typeparam>
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependência)
        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public virtual void Create(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
