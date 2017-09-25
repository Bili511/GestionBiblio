namespace TPWEB1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Membres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Membres()
        {
            Emprunts = new HashSet<Emprunts>();
        }

        [Key]
        public int idMembre { get; set; }

        public int idAdresse { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        [Required]
        [StringLength(30)]
        public string Prénom { get; set; }

        [Display(Name = "Date de naissance")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_naissance { get; set; }

        [StringLength(200)]
        public string Courriel { get; set; }


        public long Téléphone { get; set; }

        public virtual Adresses Adresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprunts> Emprunts { get; set; }

        public string FullName
        {
            get
            {
                return Nom + "  " + Prénom;
            }
        }
    }
}
