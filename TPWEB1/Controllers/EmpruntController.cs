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
    public class EmpruntController : Controller
    {
        private BibModel db = new BibModel();

        // GET: Emprunt
        public ActionResult Index()
        {
            var emprunts = db.Emprunts.Include(e => e.Livres).Include(e => e.Membres);
            return View(emprunts.ToList());
        }

        [HttpPost]
        public ActionResult chercherEmprunt(FormCollection fc) //Rajoutée
        {
            var emprunt = fc["emprunt"];
            var query = from e in db.Emprunts.Include(m => m.Membres).Include(l => l.Livres) where 
                        e.Membres.Nom.Contains(emprunt) || e.Membres.Prénom.Contains(emprunt) 
                        || e.Livres.Titre.Contains(emprunt) select e;
            return View(query.ToList());
        }

        // GET: Emprunt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunts emprunts = db.Emprunts.Find(id);
            if (emprunts == null)
            {
                return HttpNotFound();
            }
            return View(emprunts);
        }

        // GET: Emprunt/Create
        public ActionResult Create()
        {
            //Membres query           
            string query = "SELECT * FROM Membres WHERE idMembre IN (SELECT idMembre FROM Emprunts GROUP BY idMembre HAVING COUNT(idMembre) < 3) OR idMembre NOT IN (SELECT idMembre FROM Emprunts)";
            var membresConformes = db.Database.SqlQuery<Membres>(query).ToList();

            
            //Book query
            var t = from e in db.Emprunts.Include(x => x.Livres) where e.Date_Retour == null select e.idLivre;
            var  LivreRestants = (from l in db.Livres where !t.Contains(l.idLivre) select l).ToList() ;

            ViewBag.idLivre = new SelectList(LivreRestants, "idLivre", "Titre"); //to populate: public SelectList(IEnumerable items,  string dataValueField, string dataTextField, Object selectedValue)
            ViewBag.idMembre = new SelectList(membresConformes, "idMembre", "fullName");
                        
            return View();
        }
        
        // POST: Emprunt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmprunt,idMembre,idLivre,Date_Emprunt,Date_Retour")] Emprunts emprunts)
        {
            if (ModelState.IsValid)
            {
                db.Emprunts.Add(emprunts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLivre = new SelectList(db.Livres, "idLivre", "ISBN", emprunts.idLivre);
            ViewBag.idMembre = new SelectList(db.Membres, "idMembre", "Nom", emprunts.idMembre);
            return View(emprunts);
        }

        // GET: Emprunt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunts emprunts = db.Emprunts.Find(id);
            if (emprunts == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLivre = new SelectList(db.Livres, "idLivre", "ISBN", emprunts.idLivre);
            ViewBag.idMembre = new SelectList(db.Membres, "idMembre", "Nom", emprunts.idMembre);
            return View(emprunts);
        }

        // POST: Emprunt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmprunt,idMembre,idLivre,Date_Emprunt,Date_Retour")] Emprunts emprunts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprunts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLivre = new SelectList(db.Livres, "idLivre", "ISBN", emprunts.idLivre);
            ViewBag.idMembre = new SelectList(db.Membres, "idMembre", "Nom", emprunts.idMembre);
            return View(emprunts);
        }

        // GET: Emprunt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunts emprunts = db.Emprunts.Find(id);
            if (emprunts == null)
            {
                return HttpNotFound();
            }
            return View(emprunts);
        }

        // POST: Emprunt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprunts emprunts = db.Emprunts.Find(id);
            db.Emprunts.Remove(emprunts);
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
