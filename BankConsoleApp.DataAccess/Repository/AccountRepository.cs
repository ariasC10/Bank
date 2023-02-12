using BankConsoleApp.Core.Models;
using BankConsoleApp.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.DataAccess.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly MySqlDbContext _dbContext;

        public AccountRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Insert(Account model)
        {
            _dbContext.Accounts.Add(model);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<Account> GetById(int id)
        {
            return _dbContext.Accounts.Find(id);
        }

        public Task Update(Account model, float mount)
        {
            model.Balance += mount;
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }


    }
}
