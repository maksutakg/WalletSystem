using WalletSystem.Application.DTOs;
using WalletSystem.Domain.Common;
using WalletSystem.Domain.Entities;
using WalletSystem.Domain.Interfaces;
using WalletSystem.Infrastructure;

namespace WalletSystem.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task RegisterAsync(RegisterRequest request)
        {
           var exists = await _unitOfWork.Users.GetByEmaildAsync(request.Email);

           if (exists != null)
               throw new InvalidOperationException("User with this email already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User(Guid.NewGuid(), request.Name, request.Email, passwordHash);
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var Account = new Account(Guid.NewGuid(), user.Id, 0);
            await _unitOfWork.Accounts.AddAsync(Account);
            await _unitOfWork.SaveChangesAsync();


        }
        public async Task<String> LoginAsync(LoginRequest request)
        {
           var User = await _unitOfWork.Users.GetByEmaildAsync(request.Email);

            if (User==null ||!BCrypt.Net.BCrypt.Verify(request.Password,User.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");

            }

            return _tokenService.GenerateToken(User);
           
        }

       
    }
}
