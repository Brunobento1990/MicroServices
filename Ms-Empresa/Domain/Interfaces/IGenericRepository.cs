namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AdicionarAsync(T entity);
        Task<bool> EditarAsync(T entity);
        Task<bool> ExcluirAsync(T entity);
    }
}
