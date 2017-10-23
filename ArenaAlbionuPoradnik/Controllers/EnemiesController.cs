using ArenaAlbionuPoradnik.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class EnemiesController : Controller
    {
        private AADataContext db = new AADataContext();

        // GET: Enemies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnemyOfType(string type)
        {
            EnemyType enemyType = (EnemyType)System.Enum.Parse(typeof(EnemyType), type);
            return View(db.Enemies.Where(e => e.Type == enemyType).ToList());
        }
    }
}