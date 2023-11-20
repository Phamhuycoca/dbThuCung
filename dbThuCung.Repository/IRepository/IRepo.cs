using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Repository.IRepository
{
    public interface IRepo<T> where T : class, new()
    {
        List<T> GetAll();
        T Get(long id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(long id);
    }
}
