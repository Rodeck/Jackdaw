using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArenaAlbionuPoradnik.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            return View();
        }

        // GET: Database
        public ActionResult Schema()
        {
            CreateDatabaseSchemaFromMappingFiles();
            return View();
        }

        public void CreateDatabaseSchemaFromMappingFiles()
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
            NHibernate.Tool.hbm2ddl.SchemaExport schema = new NHibernate.Tool.hbm2ddl.SchemaExport(cfg);
            schema.Create(false, true);
        }

    }
}