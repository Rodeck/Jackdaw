using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace NHibernateMVC.Models
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var configurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Animal.hbm.xml");
            configuration.AddFile(configurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}