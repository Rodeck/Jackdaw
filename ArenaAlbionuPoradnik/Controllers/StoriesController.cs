using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArenaAlbionuPoradnik.Helpers;
using ArenaAlbionuPoradnik.Models;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class StoriesController : Controller
    {
        private AADataContext db = new AADataContext();

        // GET: Stories
        public ActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        public ActionResult Story(int Id)
        {
            if (Id == -1)
            {
                Id = new Random().Next(0, db.Stories.Count() - 1);
            }

            return View(db.Stories.Where(s => s.Id == Id).FirstOrDefault());
        }


    }       
}
