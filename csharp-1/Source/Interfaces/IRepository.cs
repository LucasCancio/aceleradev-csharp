using System.Collections.Generic;

namespace Source.Interfaces
{
    public interface IRepository<T> where T: class
    {
        List<T> SelectAll();
        T SelectByID(long id);
        bool Insert(T entity);
    }
}
