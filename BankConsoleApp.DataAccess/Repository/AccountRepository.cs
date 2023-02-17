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
            _dbContext.Transactions.ToList();
        }

        public Task Insert(Account model)
        {
            _dbContext.Accounts.Add(model);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Account GetById(uint id)
        {            
            return _dbContext.Accounts.Find(id);
        }

        public Task Update(Account model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
