namespace data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext")
        {
        }

        public virtual DbSet<eval360> eval360 { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<facture> factures { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<objective> objectives { get; set; }
        public virtual DbSet<partenariat> partenariats { get; set; }
        public virtual DbSet<projet> projets { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<user> users { get; set; }
      


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eval360>()
                .Property(e => e.evalDetails)
                .IsUnicode(false);

            modelBuilder.Entity<eval360>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<eval360>()
                .HasMany(e => e.feedbacks)
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
                .HasMany(e => e.factures)
                .WithRequired(e => e.mission)
                .HasForeignKey(e => e.mission_idmission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.forUserHavingRole)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.notifType)
                .IsUnicode(false);

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
                .HasMany(e => e.evaluations)
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
                .HasMany(e => e.factures)
                .WithOptional(e => e.partenariat)
                .HasForeignKey(e => e.partenariat_idpartenaire);

            modelBuilder.Entity<projet>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.projet)
                .HasForeignKey(e => e.projet_id);

            modelBuilder.Entity<team>()
                .Property(e => e.departement)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.teamName)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.users)
                .WithOptional(e => e.team)
                .HasForeignKey(e => e.team_id);

            modelBuilder.Entity<ticket>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.difficulty)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.title)
                .IsUnicode(false);

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
                .Property(e => e.cvDetails)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gitLink)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.statusEval360)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.eval360)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.concernedEmployee_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.evaluations)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.idEmploye)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.feedbacks)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.idGivenByEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.missions)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.emp_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.teams)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.manager_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.employesTicket_id);
        }
    }
}
