namespace WalletSystem.Domain.Common
{
        public class User
        {

            public Guid Id { get; set; }
             public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public string Role { get; set; } = "User";

        public User(Guid id, string name, string email, string password)
            {
                Id = id;
                Name = name;
                Email = email;
                Password = password;
            }

        }
    }
