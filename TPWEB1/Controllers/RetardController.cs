using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPWEB1.Models;
using System.Data.Entity;

namespace TPWEB1.Controllers
{
    public class RetardController : Controller
    {
        private BibModel db = new BibModel();

        // GET: Retard
        public ActionResult Index()
        {

            /*
            //MsgErreur : DbArithmeticExpression arguments must have a numeric common type.
            var subQuery = (from e in db.Emprunts where (((TimeSpan)(DateTime.Now - e.Date_Emprunt)).Days > 3 && (e.Date_Retour == null)) select e.idMembre) ;
            var finalQuery = from m in db.Membres.Include(x => x.Adresses) where subQuery.Contains(m.idMembre) select m;
            */



             string query = " SELECT * FROM Membres WHERE idMembre IN (SELECT idMembre FROM Emprunts"+
                            " WHERE DATEDIFF(DAY, Date_Emprunt, GETDATE()) > 3 AND Date_Retour IS NULL "+
                            " GROUP BY idMembre )";
             var finalQuery = db.Database.SqlQuery<Membres>(query);

            return View(finalQuery.ToList());
        }
    }
}