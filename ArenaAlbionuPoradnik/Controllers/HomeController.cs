using ArenaAlbionuPoradnik.Helpers;
using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class HomeController : Controller
    {
        private AADataContext db = new AADataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Kingdoms()
        {
            return View();
        }

        public ActionResult Location(int Id)
        {
            return View();
        }

        public ActionResult LogIn()
        {
            db.Menu.Where(s => s.Active).FirstOrDefault().State = Models.SiteState.LogedIn;
            db.SaveChanges();
            return View("Index");
        }


    }
}