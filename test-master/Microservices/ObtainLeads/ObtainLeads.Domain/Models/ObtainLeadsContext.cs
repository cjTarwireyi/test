using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObtainLeads.Domain.Models
{
    public partial class ObtainLeadsContext : DbContext
    {
        public ObtainLeadsContext()
        {
        }

        public ObtainLeadsContext(DbContextOptions<ObtainLeadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<DebitObligation> DebitObligation { get; set; }
        public virtual DbSet<DeclarationByConsumer> DeclarationByConsumer { get; set; }
        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<EmployerAddress> EmployerAddress { get; set; }
        public virtual DbSet<EmployerContactDetail> EmployerContactDetail { get; set; }
        public virtual DbSet<IncomeType> IncomeType { get; set; }
        public virtual DbSet<Lead> Lead { get; set; }
        public virtual DbSet<LeadAddress> LeadAddress { get; set; }
        public virtual DbSet<LeadContactDetail> LeadContactDetail { get; set; }
        public virtual DbSet<LeadDeduction> LeadDeduction { get; set; }
        public virtual DbSet<LeadIncome> LeadIncome { get; set; }
        public virtual DbSet<MonthlyCommitment> MonthlyCommitment { get; set; }
        public virtual DbSet<LeadObligation> LeadObligations { get; set; }
        public virtual DbSet<LeadMonthlyCommitment> LeadMonthlyCommitment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ObtainLeads;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebitObligation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DebtCommitment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyCommitment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameOfCreditor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmountOutstanding).HasColumnType("numeric(18, 0)");

                //entity.HasOne(d => d.Lead)
                //    .WithMany(p => p.DebitObligation)
                //    .HasForeignKey(d => d.LeadId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__DebitObli__LeadI__0A9D95DB");
            });

            modelBuilder.Entity<DeclarationByConsumer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Signed)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SignedAt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.DeclarationByConsumer)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Declarati__LeadI__0D7A0286");
            });

            modelBuilder.Entity<DeductionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Leads)
                    .WithMany(p => p.Employer)
                    .HasForeignKey(d => d.LeadsId)
                    .HasConstraintName("FK__Employer__LeadsI__6383C8BA");
            });

            modelBuilder.Entity<EmployerAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Line1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Line2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip).HasColumnName("zip");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.EmployerAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployerA__Addre__6754599E");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.EmployerAddress)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployerA__Emplo__66603565");
            });

            modelBuilder.Entity<EmployerContactDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.EmployerContactDetail)
                    .HasForeignKey(d => d.EmployerId)
                    .HasConstraintName("FK__EmployerC__Emplo__6A30C649");
            });

            modelBuilder.Entity<IncomeType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sent)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeadAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Line1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Line2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip).HasColumnName("zip");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.LeadAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeadAddre__Addre__73BA3083");

                entity.HasOne(d => d.Leads)
                    .WithMany(p => p.LeadAddress)
                    .HasForeignKey(d => d.LeadsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeadAddre__Leads__72C60C4A");
            });

            modelBuilder.Entity<LeadContactDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CellNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Leads)
                    .WithMany(p => p.LeadContactDetails)
                    .HasForeignKey(d => d.LeadsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeadConta__Leads__6FE99F9F");
            });

            modelBuilder.Entity<LeadDeduction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                //entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                //entity.HasOne(d => d.DeductionType)
                //    .WithMany(p => p.LeadDeduction)
                //    .HasForeignKey(d => d.DeductionTypeId)
                //    .HasConstraintName("FK__LeadDeduc__Deduc__7F2BE32F");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.LeadDeduction)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__LeadDeduc__LeadI__7E37BEF6");
            });

            modelBuilder.Entity<LeadIncome>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.LeadIncome)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .HasConstraintName("FK__LeadIncom__Incom__04E4BC85");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.LeadIncome)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__LeadIncom__LeadI__03F0984C");
            });

            modelBuilder.Entity<MonthlyCommitment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Commitment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyExpense).HasColumnType("numeric(18, 0)");

                //entity.HasOne(d => d.Lead)
                //    .WithMany(p => p.MonthlyCommitments)
                //    .HasForeignKey(d => d.LeadId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__MonthlyCo__LeadI__07C12930");
            });
        }
    }
}
