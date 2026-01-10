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

        public void Deposit(decimal amount)
        {

                      if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
                    Balance += amount;

        }

        public void WithDraw(decimal amount) 
        {
                if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            Balance -= amount;
        }
    }
}
