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

        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<recommendation> recommendations { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<skilljob> skilljobs { get; set; }
        public virtual DbSet<skillmatrix> skillmatrices { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<job>()
                .HasMany(e => e.skilljobs)
                .WithOptional(e => e.job)
                .HasForeignKey(e => e.job_jobId);

            modelBuilder.Entity<recommendation>()
                .Property(e => e.recDesc)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.skillDesc)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.skillName)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .HasMany(e => e.skillmatrices)
                .WithOptional(e => e.skill)
                .HasForeignKey(e => e.skill_skillId);

            modelBuilder.Entity<skill>()
                .HasMany(e => e.skilljobs)
                .WithOptional(e => e.skill)
                .HasForeignKey(e => e.skill_skillId);

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

            modelBuilder.Entity<user>()
                .HasMany(e => e.skillmatrices)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.employee_id);
        }
    }
}
