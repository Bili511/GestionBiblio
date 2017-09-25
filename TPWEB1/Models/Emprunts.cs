namespace TPWEB1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    public partial class Emprunts
    {
        [Key]
        public int idEmprunt { get; set; }
        
        public int idMembre { get; set; }

        public int idLivre { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Emprunt { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Retour { get; set; }

        public virtual Livres Livres { get; set; }

        public virtual Membres Membres { get; set; }

        internal static object Contains(int idLivre)
        {
            throw new NotImplementedException();
        }

        
    }
}
