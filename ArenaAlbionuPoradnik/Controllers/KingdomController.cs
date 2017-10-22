using ArenaAlbionuPoradnik.Helpers;
using ArenaAlbionuPoradnik.Mappings;
using ArenaAlbionuPoradnik.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class KingdomController : Controller
    {
        ISessionFactory sessionFactory;
        ISession session;

        private AADataContext db = new AADataContext();

        public KingdomController()
        {
            //sessionFactory = CreateSessionFactory();
            //session = sessionFactory.OpenSession();
        }

        // GET: Kingdom
        public ActionResult Index(int Id)
        {
            NKingdom kingdom;

            //using (session.BeginTransaction())
            //{
            //    kingdom = session.CreateCriteria(typeof(NKingdom)).List<NKingdom>().Where(k => k.Id == Id).FirstOrDefault();            
            //}

            kingdom = db.Kingdoms.ToList()[0];

            return View(kingdom);
        }

        private static ISessionFactory CreateSessionFactory()
        {

            var cfg = MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("connectionString"));

            return Fluently.Configure().
                Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NKingdomMap>())
                .BuildSessionFactory();
        }
    }
}