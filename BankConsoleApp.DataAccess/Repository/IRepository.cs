using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Domain.Repository
{
    public interface IRepository<TModel> where TModel : class, new()
    {
        Task<bool> Add(TModel model);
        Task<TModel> GetById(int id);
        Task<bool> Update(TModel model, double mount);
    }
}
