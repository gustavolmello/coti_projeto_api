using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repository.Interfaces
{
    /// <summary>
    /// Interface genérica para definir os métodos do repositório
    /// </summary>
    /// <typeparam name="T">Tipo genérico que representa qualquer classe de entidade</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
