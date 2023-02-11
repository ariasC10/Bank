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
    internal class MySqlRepository : IRepository<Account>
    {
        private readonly DbContext _dbContext;

        public MySqlRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Add(Account model)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Account model, double mount)
        {
            throw new NotImplementedException();
        }
    }
}
