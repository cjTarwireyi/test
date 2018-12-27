using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Leads.Data.Models
{
    public partial class LeadsDemo_v1Context : DbContext
    {
        public LeadsDemo_v1Context()
        {
        }

        public LeadsDemo_v1Context(DbContextOptions<LeadsDemo_v1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<CustomerContactDetail> CustomerContactDetail { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LeadsDemo_v1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerAddress)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustomerAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Custom__29572725");

                entity.HasOne(d => d.CustomerContactDetails)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustomerContactDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Custom__2A4B4B5E");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Employ__2B3F6F97");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerContactDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CellNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployerAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
