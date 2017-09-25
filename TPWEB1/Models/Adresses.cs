namespace TPWEB1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adresses()
        {
            Membres = new HashSet<Membres>();
        }

        [Key]
        public int idAdresse { get; set; }

        [Column("Numéro civique")]
        public int Numéro_civique { get; set; }

        [Required]
        [StringLength(200)]
        public string Rue { get; set; }

        [Required]
        [StringLength(200)]
        public string Ville { get; set; }

        [Column("Code postal")]
        [Required]
        [StringLength(6)]
        public string Code_postal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membres> Membres { get; set; }
    }
}
