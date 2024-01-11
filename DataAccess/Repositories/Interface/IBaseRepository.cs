using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
