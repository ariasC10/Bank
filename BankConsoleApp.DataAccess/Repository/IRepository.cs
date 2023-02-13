namespace BankConsoleApp.DataAccess.Repository
{
    public interface IRepository<TModel> where TModel : class, new()
    {
        Task Insert(TModel model);
        TModel GetById(uint id);
        Task Update(TModel model);
    }
}
