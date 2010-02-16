using NHibernateHelper.Repository.NHibernate;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class NHibernateIntegrationTest
    {
        [Test]
        public void GenerateSchema()
        {
            var repo = new NHibernateRepository<NHibernateIntegrationTest>();
            repo.GenerateSchema(SanityCheck.ThisWillDropMyDatabase);
        }
    }
}
