namespace Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Employe")
        {
        }

        public virtual DbSet<employe> employe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
