using BankConsoleApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.DataAccess.Db
{
    public partial class MySqlDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public MySqlDbContext() {}

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=database-bank.c1k9xnmjxukl.us-east-1.rds.amazonaws.com;database=bank;user=admin;password=proyectojorge", ServerVersion.Parse("8.0.32-mysql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Transaction>().ToTable("Trasactions");
        }
    }
}

// scaffold-dbcontext "server=database-bank.c1k9xnmjxukl.us-east-1.rds.amazonaws.com; database=bank; user=admin; password=proyectojorge;" Pomelo.EntityFrameworkCore.Mysql -outputdir Models -context PostDbContext -force
