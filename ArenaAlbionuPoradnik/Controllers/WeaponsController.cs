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
    public class WeaponsController : Controller
    {
        private AADataContext db = new AADataContext();

        // GET: Weapons
        public ActionResult Index()
        {
            return View(db.Items.OfType<Weapon>().ToList());
        }

        // GET: Weapons
        public ActionResult WeaponType(string type)
        {
            EquipableType weaponType = (EquipableType)System.Enum.Parse(typeof(EquipableType), type);
            return View(db.Items.OfType<Weapon>().Where(s => s.WeaponType == weaponType).ToList());
        }

        public ActionResult ArmorType(string type)
        {
            EquipableType weaponType = (EquipableType)System.Enum.Parse(typeof(EquipableType), type);
            return View(db.Items.OfType<Armor>().Where(s => s.WeaponType == weaponType).ToList());
        }

        // GET: Weapons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = (Weapon)db.Items.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // GET: Weapons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Name,Image,Attack,ConditionUse,Durability")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(weapon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weapon);
        }

        // GET: Weapons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = (Weapon)db.Items.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Name,Image,Attack,ConditionUse,Durability")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weapon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = (Weapon)db.Items.Find(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weapon weapon = (Weapon)db.Items.Find(id);
            db.Items.Remove(weapon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
