using WalletSystem.Domain.Common;
using WalletSystem.Domain.Entities;
using WalletSystem.Infrastructure.Repository;

namespace WalletSystem.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User>Users { get; }
        IRepository<Account> Accounts { get; }
        Task<int> SaveChangesAsync();
    }
}
