using GLMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = await _authService.Register(username, password);
            return Ok(user);
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.Login(username, password);
            return Ok(new { token });
        }
    }
}