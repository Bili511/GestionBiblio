using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Xml;
using System.Web;
using System.Web.Mvc;
using TPWEB1.Models;
using System.Data.SqlClient;  // A ajouter pour avoir SqlConnection, SqlCommand....

namespace TPWEB1.Controllers
{
    public class MembreController : Controller
    {
        private BibModel db = new BibModel();

        // GET: Membre
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                var membres = db.Membres.Include(m => m.Adresses);
                return View(membres.ToList());
            }
            else
            {
                int subQuery = (from e in db.Emprunts where e.idLivre == id select e.idMembre).First();
                var membres = from m in db.Membres.Include(a => a.Adresses) where m.idMembre == subQuery select m;

                ViewBag.membres1 = membres.Count();
                ViewBag.membres2 = subQuery;


                return View(membres.ToList());
            }
        }

        [HttpPost]
        public ActionResult chercherMembre(FormCollection fc) 
        {            
            var nom = fc["nom"];
            /*Don't work
                    var m = db.Database.SqlQuery<Membres>("select * from Membres where Nom like '%"+nom+"%' or Prénom like '%"+ nom +"%'").ToList();
                ou var m = db.Membres.SqlQuery("select * from Membres where Nom like '%" + nom + "%' or Prénom like '%" + nom + "%'")*/

            // Basic LINQ Query Operations (C#)
            var query = from c in db.Membres.Include(c => c.Adresses) where c.Nom.Contains(nom) || c.Prénom.Contains(nom) select c;
            return View(query.ToList());
 
        }


        // GET: Membre/Details/5
        public ActionResult Details(int? id)  //Rajoutée
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membres membres = db.Membres.Find(id);
            if (membres == null)
            {
                return HttpNotFound();
            }
            
            return View(membres);
        }

        // GET: Membre/Create
        public ActionResult Create()
        {
            ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "idAdresse");
            return View();
        }

        // POST: Membre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAdresse,Numéro_civique,Rue,Ville,Code_postal")] Adresses adresses, [Bind(Include = "idMembre,idAdresse,Nom,Prénom, Date_naissance,Courriel,Téléphone")] Membres membres)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(adresses);
                db.Membres.Add(membres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "idAdresse", membres.idAdresse);
            return View(membres);
        }

        // GET: Membre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membres membres = db.Membres.Find(id);
            if (membres == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "idAdresse", membres.idAdresse);
            //ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "Rue", membres.idAdresse);
            return View(membres);
        }

        // POST: Membre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMembre,idAdresse,Nom,Prénom,Date_naissance,Courriel,Téléphone")] Membres membres, [Bind(Include = "idAdresse, Numéro_civique, Rue, Ville, Code_postal")] Adresses adresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresses).State = EntityState.Modified;
                db.Entry(membres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "idAdresse", membres.idAdresse);
            //ViewBag.idAdresse = new SelectList(db.Adresses, "idAdresse", "Rue", membres.idAdresse);
            return View(membres);
        }

        // GET: Membre/Delete/5
        public ActionResult Delete(int? id1, int ? id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membres membres = db.Membres.Find(id1);
            if (membres == null)
            {
                return HttpNotFound();
            }
            return View(membres);
        }

        // POST: Membre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id1, int id2)
        {
            Membres membres = db.Membres.Find(id1);
            db.Membres.Remove(membres);
            Adresses adresses = db.Adresses.Find(id2);
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
