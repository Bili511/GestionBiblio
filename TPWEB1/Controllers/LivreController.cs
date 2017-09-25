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
    public class LivreController : Controller
    {
        private BibModel db = new BibModel();

        public static BibModel infos = new BibModel(); 
        // GET: Livre
        public ActionResult Index()
        {
            return View(db.Livres.ToList());
        }

        [HttpPost]
        public ActionResult chercherLivre(FormCollection fc) 
        {
            var titre = fc["titre"];
            var query = from l in db.Livres where l.Titre.Contains(titre) || l.Auteur.Contains(titre) select l;
            return View(query.ToList());
        }

        // GET: Livre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // GET: Livre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLivre,ISBN,Titre,Auteur,Année_Édition,Catégorie")] Livres livres)
        {
            if (ModelState.IsValid)
            {
                db.Livres.Add(livres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livres);
        }

        // GET: Livre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // POST: Livre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLivre,ISBN,Titre,Auteur,Année_Édition,Catégorie")] Livres livres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livres);
        }

        // GET: Livre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // POST: Livre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livres livres = db.Livres.Find(id);
            db.Livres.Remove(livres);
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
