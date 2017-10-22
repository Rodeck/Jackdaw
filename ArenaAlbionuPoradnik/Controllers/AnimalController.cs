using ArenaAlbionuPoradnik.Models;
using NHibernate;
using NHibernateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var persons = session.Query<Animal>().ToList();
                return View(persons);
            }
        }
    }
}