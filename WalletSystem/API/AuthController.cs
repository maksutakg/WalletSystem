using Microsoft.AspNetCore.Mvc;
using WalletSystem.Application.DTOs;
using WalletSystem.Domain.Interfaces;

namespace WalletSystem.API
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterRequest request)
        {
            await _authService.RegisterAsync(request);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginRequest request)
        {
            await _authService.LoginAsync(request);
            return Ok(); 
        }
    }
}
