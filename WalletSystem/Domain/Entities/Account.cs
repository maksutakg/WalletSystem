namespace WalletSystem.Domain.Entities
{
    public class Account
    {
      
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }

        protected Account() { } 

        public Account(Guid id, Guid userId, decimal balance)
        {
            Id = id;
            UserId = userId;
            Balance = balance;
        }
    }
}
