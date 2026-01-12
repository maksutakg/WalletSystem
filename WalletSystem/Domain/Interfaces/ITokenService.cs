using WalletSystem.Domain.Common;

namespace WalletSystem.Domain.Interfaces
{
    public interface ITokenService
    {
      string GenerateToken(User user);

    }
}
