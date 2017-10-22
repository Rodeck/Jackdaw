using ArenaAlbionuPoradnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Overview(NLocation loc)
        {
            return View(loc);
        }
    }
}