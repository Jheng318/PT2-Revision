using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PT2Revision.Models
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<StudentResults> StudentResults { get; set; }
        public virtual DbSet<Students> Students { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK__Modules__2B7477A7A1FAC07E");

                entity.Property(e => e.ModuleCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ModuleName).IsRequired();
            });

            modelBuilder.Entity<StudentResults>(entity =>
            {
                entity.HasKey(e => e.ResultsId)
                    .HasName("PK__StudentR__45CAFA77B056BE81");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentResults_ToModule");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentResults)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentResults_ToStudents");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52B998179030B");

                entity.Property(e => e.AdminNo)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
