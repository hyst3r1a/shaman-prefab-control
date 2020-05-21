using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShamanPrefabControl
{
    public partial class d905g2ke1a5qvmContext : DbContext
    {
        public d905g2ke1a5qvmContext()
        {
        }

        public d905g2ke1a5qvmContext(DbContextOptions<d905g2ke1a5qvmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Prefabs> Prefabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=ec2-54-75-231-215.eu-west-1.compute.amazonaws.com;Port=5432;Username=cmwebymzxchfzt;Password=389d48d2677ab6783d75f0295f776c657f230f12d03ea581a179280112a3ab9f;Database=d905g2ke1a5qvm;sslmode=Require;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prefabs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
