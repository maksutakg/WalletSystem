
using WalletSystem.Application.DTOs;
namespace WalletSystem.Domain.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequest request);
        Task LoginAsync(LoginRequest request);
    }
}
