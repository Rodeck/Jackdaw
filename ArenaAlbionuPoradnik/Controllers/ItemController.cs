using ArenaAlbionuPoradnik.Helpers;
using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class ItemController : Controller
    {
        private AADataContext db = new AADataContext();

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        // GET: Weapons
        public ActionResult ItemType(string type)
        {
            ItemType itemType = (ItemType)System.Enum.Parse(typeof(ItemType), type);
            return View(db.Items.OfType<Item>().Where(s => s.Type == itemType).ToList());
        }

        // GET: Weapons
        public ActionResult RawMaterials()
        {
            return View(db.RawMaterials.ToList());
        }
    }
}