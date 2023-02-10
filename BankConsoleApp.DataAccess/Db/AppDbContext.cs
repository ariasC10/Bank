using BankConsoleApp.Core.Accounts;
using Microsoft.EntityFrameworkCore;

namespace BankConsoleApp.DataAccess.Db
{
    public class AppDBContext : DbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        private const string connectionString = "server=database-bank.c1k9xnmjxukl.us-east-1.rds.amazonaws.com; database=bank; user=admin; password=proyectojorge; SslMode=VerifyFull;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
