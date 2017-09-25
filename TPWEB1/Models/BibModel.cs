namespace TPWEB1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    

    public partial class BibModel : DbContext
    {
        public BibModel()
            : base("name=BibModel")
        {
        }
       
        public virtual DbSet<Adresses> Adresses { get; set; }
        public virtual DbSet<Emprunts> Emprunts { get; set; }
        public virtual DbSet<Livres> Livres { get; set; }
        public virtual DbSet<Membres> Membres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresses>()
                .Property(e => e.Rue)
                .IsUnicode(false);

            modelBuilder.Entity<Adresses>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Adresses>()
                .Property(e => e.Code_postal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Livres>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Livres>()
                .Property(e => e.Titre)
                .IsUnicode(false);

            modelBuilder.Entity<Livres>()
                .Property(e => e.Auteur)
                .IsUnicode(false);

            modelBuilder.Entity<Livres>()
                .Property(e => e.Catégorie)
                .IsUnicode(false);

            modelBuilder.Entity<Membres>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Membres>()
                .Property(e => e.Prénom)
                .IsUnicode(false);

            modelBuilder.Entity<Membres>()
               .Property(e => e.Courriel)
               .IsUnicode(false);

        }
    }
}
