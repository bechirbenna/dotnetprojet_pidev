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

        public virtual DbSet<centres> centress { get; set; }
        public virtual DbSet<employer> employers { get; set; }
        public virtual DbSet<evaluation> evaluations { get; set; }
        public virtual DbSet<formateur> formateurs { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<planification> planifications { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<empfor> empfors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.specialite)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .HasMany(e => e.planifications)
                .WithOptional(e => e.formateur)
                .HasForeignKey(e => e.idFormateur);

            modelBuilder.Entity<formation>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.nomFormation)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .HasMany(e => e.planifications)
                .WithOptional(e => e.formation)
                .HasForeignKey(e => e.idFormation);

            modelBuilder.Entity<job>()
                .Property(e => e.jobDesc)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.jobName)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .HasMany(e => e.users)
                .WithOptional(e => e.job)
                .HasForeignKey(e => e.job_jobId);

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
                .Property(e => e.cin)
                .IsUnicode(false);
        }
    }
}
