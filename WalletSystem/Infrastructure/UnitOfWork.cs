using WalletSystem.Domain.Common;
using WalletSystem.Domain.Entities;
using WalletSystem.Domain.Interfaces;
using WalletSystem.Infrastructure.Persistence;
using WalletSystem.Infrastructure.Repository;

namespace WalletSystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<User> Users { get; }
        public IRepository<Account> Accounts { get; }

        public UnitOfWork(AppDbContext context, IRepository<User> user, IRepository<Account> account)
        {
            _context = context;
            Users = new Repository<User>(_context);
            Accounts = new Repository<Account>(_context);

        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}


