using ArenaAlbionuPoradnik.Helpers;
using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class MenuController : Controller
    {
        private AADataContext db = new AADataContext();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadMenu()
        {
            MenuModel model = db.Menu.Where(s => s.Active).FirstOrDefault();

            model.isLogged = this.Request.IsAuthenticated ? true : false;

            return PartialView("_Menu", model);
        }



        public ActionResult LoadUserPanel()
        {
            return PartialView("_UserPanel");
        }

    }
}