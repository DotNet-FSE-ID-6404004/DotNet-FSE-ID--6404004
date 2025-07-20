using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (model.Username == "admin" && model.Password == "password")
            {
                var token = _authService.GenerateJwtToken(model.Username, "Admin");
                return Ok(new LoginResponse { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
