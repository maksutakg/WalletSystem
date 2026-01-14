using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WalletSystem.Application.DTOs;
using WalletSystem.Application.Validators;
using WalletSystem.Domain.Interfaces;

namespace WalletSystem.API
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterRequest> _validator;    
        public AuthController(IAuthService authService, IValidator<RegisterRequest> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errors = result.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new ValidationProblemDetails(errors));
            }

            await _authService.RegisterAsync(request);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody]LoginRequest request)
        {
            var token= await _authService.LoginAsync(request);
            return Ok(token); 
        }
    }
}
