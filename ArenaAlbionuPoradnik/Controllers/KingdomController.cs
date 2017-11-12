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
            return View(db.Kingdoms.Where(s => s.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult LocationData(int placeId)
        {
            var model = db.Places.Where(p => p.Id == placeId).FirstOrDefault();
            return PartialView("_LocationData", model);
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