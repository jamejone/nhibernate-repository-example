using System.Collections.Generic;

namespace NHibernateHelper.Repository
{
    public interface IMonkeyRepository : IRepository<Monkey>
    {
        /// <summary>
        /// Extending IRepository is appropriate when you need class-specific
        /// functionality that IRepository doesn't provide. Therefore, the
        /// function name should be named to fit the business requirement.
        /// </summary>
        IList<Monkey> GetPooFlingingMonkeys();
    }
}
