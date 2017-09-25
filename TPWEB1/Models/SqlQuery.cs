using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWEB1.Models
{
    public class SqlQuery
    {
        public static BibModel db = new BibModel();
        public static Dictionary<string, int> detailsEmprunts(int id)
        {
            Dictionary<string,int> dic = new Dictionary<string, int>();

            int nbLivreEmp = db.Database.SqlQuery<int>("select count(idEmprunt) from Emprunts where Date_Retour is null and idMembre =" + id).First();
            
            int nbLivreNonRetournés = db.Database.SqlQuery<int>("SELECT COUNT(idEmprunt) FROM Emprunts WHERE DATEDIFF(DAY, Date_Emprunt, GETDATE()) > 3 AND Date_Retour IS NULL AND idMembre =" + id).First();
            dic.Add("nbLivreEmp", nbLivreEmp);
            dic.Add("nbLivreNonRetournés", nbLivreNonRetournés);
            return (dic);
        }

        /*public static int compter(string query)
        {
            int nb = TPWEB1.Models.SqlQuery.db.Database.SqlQuery<int>(query).First();
            return nb;
        }*/

    }
}