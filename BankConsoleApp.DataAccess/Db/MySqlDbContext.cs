using BankConsoleApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.DataAccess.Db
{
    public partial class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {
        }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=database-bank.c1k9xnmjxukl.us-east-1.rds.amazonaws.com;database=bank;user=admin;password=proyectojorge", ServerVersion.Parse("8.0.32-mysql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber).HasName("PRIMARY");

                entity.ToTable("account");

                entity.Property(e => e.AccountNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("account_number");
                entity.Property(e => e.AccountType)
                    .HasMaxLength(7)
                    .HasColumnName("account_type");
                entity.Property(e => e.Balance).HasColumnName("balance");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.Owner)
                    .HasMaxLength(45)
                    .HasColumnName("owner");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionNumber).HasName("PRIMARY");

                entity.ToTable("transaction");

                entity.HasIndex(e => e.AccountNumber, "fk_accountnumber_idx");

                entity.Property(e => e.TransactionNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_number");
                entity.Property(e => e.AccountNumber).HasColumnName("account_number");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'N/A'")
                    .HasColumnName("description");
                entity.Property(e => e.Mount).HasColumnName("mount");

                entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_accountnumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

// scaffold-dbcontext "server=database-bank.c1k9xnmjxukl.us-east-1.rds.amazonaws.com; database=bank; user=admin; password=proyectojorge;" Pomelo.EntityFrameworkCore.Mysql -outputdir Models -context PostDbContext -force
