namespace data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext")
        {
        }

        public virtual DbSet<eval360> eval360 { get; set; }
        public virtual DbSet<evaluation> evaluation { get; set; }
        public virtual DbSet<facture> facture { get; set; }
        public virtual DbSet<feedback> feedback { get; set; }
        public virtual DbSet<mission> mission { get; set; }
        public virtual DbSet<objective> objective { get; set; }
        public virtual DbSet<partenariat> partenariat { get; set; }
        public virtual DbSet<reclamation> reclamation { get; set; }
        public virtual DbSet<team> team { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eval360>()
                .Property(e => e.evalDetails)
                .IsUnicode(false);

            modelBuilder.Entity<eval360>()
                .HasMany(e => e.feedback)
                .WithRequired(e => e.eval360)
                .HasForeignKey(e => e.idEval360)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<facture>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<facture>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<feedback>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.objectif)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.territoire)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.facture)
                .WithRequired(e => e.mission)
                .HasForeignKey(e => e.mission_idmission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<objective>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<objective>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<objective>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<objective>()
                .HasMany(e => e.evaluation)
                .WithRequired(e => e.objective)
                .HasForeignKey(e => e.idObjective)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<partenariat>()
                .Property(e => e.adressepartenaire)
                .IsUnicode(false);

            modelBuilder.Entity<partenariat>()
                .Property(e => e.domainepartenaire)
                .IsUnicode(false);

            modelBuilder.Entity<partenariat>()
                .Property(e => e.emailpartenaire)
                .IsUnicode(false);

            modelBuilder.Entity<partenariat>()
                .Property(e => e.nompartenaire)
                .IsUnicode(false);

            modelBuilder.Entity<partenariat>()
                .HasMany(e => e.facture)
                .WithOptional(e => e.partenariat)
                .HasForeignKey(e => e.partenariat_idpartenaire);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.descriptif)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.departement)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.teamName)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.user)
                .WithOptional(e => e.team)
                .HasForeignKey(e => e.team_id);

            modelBuilder.Entity<user>()
                .Property(e => e.user_role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cvDetails)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gitLink)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.statusEval360)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.eval360)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.concernedEmployee_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.evaluation)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.idEmploye)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.feedback)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.idGivenByEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.mission)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.emp_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.team1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.manager_id);
        }
    }
}
