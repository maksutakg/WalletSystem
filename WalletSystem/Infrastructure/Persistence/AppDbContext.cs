using Microsoft.EntityFrameworkCore;
using WalletSystem.Domain.Common;
using WalletSystem.Domain.Entities;

namespace WalletSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       DbSet<User> Users { get; set; }
       DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();

            // Account 
            modelBuilder.Entity<Account>().HasKey(u => u.Id);
            modelBuilder.Entity<Account>().HasOne<User>().WithMany().HasForeignKey(a => a.UserId);



        }
    }

}
