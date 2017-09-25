namespace TPWEB1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Livres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Livres()
        {
            Emprunts = new HashSet<Emprunts>();
        }

        [Key]
        public int idLivre { get; set; }

        [Required]
        [StringLength(200)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(200)]
        public string Titre { get; set; }

        [Required]
        [StringLength(200)]
        public string Auteur { get; set; }

        [Column("Année Édition")]
        public int Année_Édition { get; set; }

        [Required]
        [StringLength(200)]
        public string Catégorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprunts> Emprunts { get; set; }
    }
}
