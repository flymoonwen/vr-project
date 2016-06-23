using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate;
using NHibernate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using System.Reflection;

namespace Test
{
    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory = null;

        private static void Init()
        {
           // var modle = AutoMap.Assembly(Assembly.Load("Test.Model")).Where(t=>t.Namespace == "Test.Model").IgnoreBase<BaseEntity>();
            _sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("vm_db")
            .Username("root")
            .Password("flymoonwen")))
            .Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
            .BuildSessionFactory();
                          
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if( _sessionFactory == null)
                {
                    Init();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
