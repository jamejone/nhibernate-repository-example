using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateHelper.Repository
{
    public class MockRepository<T> : IRepository<T>
    {
        public IDictionary<int, T> dictionary;

        public MockRepository()
        {
            dictionary = new Dictionary<int, T>();
        }

        public T Get(object id)
        {
            return dictionary[(int)id];
        }

        public T Save(T value)
        {
            dictionary.Add(value.GetHashCode(), value);
            return value;
        }

        public void Update(T value)
        {
            dictionary.Remove(value.GetHashCode());
            dictionary.Add(value.GetHashCode(), value);
        }

        public void Delete(T value)
        {
            dictionary.Remove(value.GetHashCode());
        }

        public IList<T> GetAll()
        {
            return dictionary.Values.ToList<T>();
        }
    }
}
