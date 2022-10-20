using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetEntity(int? id);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
