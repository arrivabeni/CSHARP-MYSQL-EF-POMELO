using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace com.mynamespace
{
    public partial class sampledbContext : DbContext
    {
        public sampledbContext()
        {
        }

        public sampledbContext(DbContextOptions<sampledbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=sampledb;User=root;Password=jX[fo/evW7FZtrmzB/Ew/I0R1|%k_0s;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.Idaddresses);

                entity.ToTable("addresses");

                entity.HasIndex(e => e.Idemployee)
                    .HasName("employee_address_idx");

                entity.Property(e => e.Idaddresses)
                    .HasColumnName("idaddresses")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Idemployee)
                    .HasColumnName("idemployee")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdemployeeNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Idemployee)
                    .HasConstraintName("employee_address");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Idemployees);

                entity.ToTable("employees");

                entity.Property(e => e.Idemployees)
                    .HasColumnName("idemployees")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
