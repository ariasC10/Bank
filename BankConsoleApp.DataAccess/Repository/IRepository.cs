namespace BankConsoleApp.DataAccess.Repository
{
    public interface IRepository<TModel> where TModel : class, new()
    {
        Task Insert(TModel model);
        Task<TModel> GetById(int id);
        Task Update(TModel model, float mount);
    }
}
