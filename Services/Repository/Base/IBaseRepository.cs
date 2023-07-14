namespace Schedule.Services.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}
