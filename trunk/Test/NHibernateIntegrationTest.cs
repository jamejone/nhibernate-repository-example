using System.Collections.Generic;
using NUnit.Framework;
using RepositoryExample;
using RepositoryExample.Repository;
using RepositoryExample.Repository.NHibernate;

namespace Test
{
    [TestFixture]
    public class NHibernateIntegrationTest
    {
        [SetUp]
        public void GenerateSchema()
        {
            var repo = new NHibernateRepository<NHibernateIntegrationTest>();
            repo.GenerateSchema(SanityCheck.ThisWillDropMyDatabase);
        }

        [Test]
        public void IntegrationTest()
        {
            IList<Banana> bananas = new List<Banana>();
            bananas.Add(new Banana() { Color = "Brown" });
            bananas.Add(new Banana() { Color = "Yellow" });

            IRepository<Banana> bRepo = new NHibernateRepository<Banana>();
            foreach (Banana b in bananas)
                bRepo.Save(b);

            Assert.IsTrue(bRepo.GetAll().Count == bananas.Count);

            IList<Monkey> monkeys = new List<Monkey>();
            monkeys.Add(new Monkey() { Name = "George", FlingsPoo = true, Bananas = bananas });
            monkeys.Add(new Monkey() { Name = "Magilla", FlingsPoo = false });

            IRepository<Monkey> mRepo = new NHibernateRepository<Monkey>();
            foreach (Monkey m in monkeys)
                mRepo.Save(m);

            Assert.IsTrue(mRepo.GetAll().Count == monkeys.Count);

            Monkey tempMonkey;
            tempMonkey = mRepo.Get(monkeys[0].Id);
            Assert.IsNotNull(tempMonkey);
            tempMonkey = mRepo.Get(-1);
            Assert.IsNull(tempMonkey);

            IMonkeyRepository imRepo = new MonkeyRepository();
            Assert.IsTrue(imRepo.GetPooFlingingMonkeys().Count == 1);

            foreach (Banana b in bananas)
                bRepo.Delete(b);

            Assert.IsTrue(bRepo.GetAll().Count == 0);

            foreach (Monkey m in monkeys)
                mRepo.Delete(m);

            Assert.IsTrue(mRepo.GetAll().Count == 0);
        }
    }
}
