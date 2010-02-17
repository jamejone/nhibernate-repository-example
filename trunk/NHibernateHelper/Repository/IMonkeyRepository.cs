using System.Collections.Generic;

namespace NHibernateHelper.Repository
{
    public interface IMonkeyRepository : IRepository<Monkey>
    {
        IList<Monkey> GetPooFlingingMonkeys();
    }
}
