using WalletSystem.Application.DTOs;
using WalletSystem.Domain.Common;
using WalletSystem.Domain.Entities;
using WalletSystem.Domain.Interfaces;
using WalletSystem.Infrastructure;

namespace WalletSystem.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task LoginAsync(LoginRequest request)
        {
            
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
          var exists = await _unitOfWork.Users.GetByEmaildAsync(request.Email); 
               
            if (exists!=null)
                throw new Exception("User with this email already exists.");

           var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User(request.Name, request.Email, passwordHash);
           await _unitOfWork.Users.AddAsync(user);
           var Account = new Account(user.Id,0);

            await _unitOfWork.Accounts.AddAsync();


        }
    }
}
