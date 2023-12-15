namespace CleanArchMvc.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T> DeleteAsync(T obj);
    }
}
