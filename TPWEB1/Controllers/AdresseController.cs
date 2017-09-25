using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPWEB1.Models;

namespace TPWEB1.Controllers
{
    public class AdresseController : Controller
    {
        private BibModel db = new BibModel();

        // GET: Adresse
        public ActionResult Index()
        {
            return View(db.Adresses.ToList());
        }

        // GET: Adresse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresses adresses = db.Adresses.Find(id);
            if (adresses == null)
            {
                return HttpNotFound();
            }
            return View(adresses);
        }

        // GET: Adresse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adresse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAdresse,Numéro_civique,Rue,Ville,Code_postal")] Adresses adresses)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(adresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adresses);
        }

        // GET: Adresse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresses adresses = db.Adresses.Find(id);
            if (adresses == null)
            {
                return HttpNotFound();
            }
            return View(adresses);
        }

        // POST: Adresse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAdresse,Numéro_civique,Rue,Ville,Code_postal")] Adresses adresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresses);
        }

        // GET: Adresse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresses adresses = db.Adresses.Find(id);
            if (adresses == null)
            {
                return HttpNotFound();
            }
            return View(adresses);
        }

        // POST: Adresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresses adresses = db.Adresses.Find(id);
            db.Adresses.Remove(adresses);
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
