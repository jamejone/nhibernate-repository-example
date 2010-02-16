using System.Collections.Generic;

namespace NHibernateHelper.Repository
{
    public interface IRepository<T>
    {
        T Get(object id);
        T Save(T value);
        void Update(T value);
        void Delete(T value);
        IList<T> GetAll();
    }
}
