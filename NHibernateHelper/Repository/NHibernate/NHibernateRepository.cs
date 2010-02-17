using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateHelper.Repository.NHibernate
{
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;

        public NHibernateRepository()
        {
            config = Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository<T>>())
                .BuildConfiguration();

            sessionFactory = config.BuildSessionFactory();
        }

        public T Get(object id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                T returnVal = session.Get<T>(id);
                transaction.Commit();
                return returnVal;
            }
        }

        public void Save(T value)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(value);
                transaction.Commit();
            }
        }

        public void Update(T value)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(value);
                transaction.Commit();
            }
        }

        public void Delete(T value)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(value);
                transaction.Commit();
            }
        }

        public IList<T> GetAll()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                IList<T> returnVal = session.CreateCriteria<T>().List<T>();
                transaction.Commit();
                return returnVal;
            }
        }

        public void GenerateSchema(SanityCheck AreYouSure)
        {
            new SchemaExport(config).Execute(true, true, false);
        }
    }

    public enum SanityCheck
    {
        /// <summary>
        /// By executing this function you risk loss of data. All mapped entity tables will be DROPPED.
        /// </summary>
        ThisWillDropMyDatabase
    }
}
