namespace BankConsoleApp.DataAccess.Repository
{
    public interface IRepository<TModel> where TModel : class, new()
    {
        Task<bool> Add(TModel model);
        Task<TModel> GetById(int id);
        Task<bool> Update(TModel model, double mount);
    }
}
