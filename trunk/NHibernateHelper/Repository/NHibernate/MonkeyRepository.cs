using System.Collections.Generic;
using NHibernate.Criterion;

namespace NHibernateHelper.Repository.NHibernate
{
    public class MonkeyRepository : NHibernateRepository<Monkey>, IMonkeyRepository
    {
        public IList<Monkey> GetPooFlingingMonkeys()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                IList<Monkey> returnVal = session.CreateCriteria<Monkey>()
                    .Add(Restrictions.Eq("FlingsPoo", true))
                    .List<Monkey>();
                transaction.Commit();
                return returnVal;
            }
        }
    }
}
