using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WalletSystem.API
{

    [ApiController]
    [Route("api/Test")]
    public class TestController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
           return Ok("Auth working ");

        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("Admin working");
        }


    }
}
