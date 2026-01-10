namespace WalletSystem.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<T?> GetByEmaildAsync(string mail);
        void Update(T entity);
        void Remove(T entity);
    }

}
