using ADars1.Models;
using ADars1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADars1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;

        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var token = await _authService.Login(request);

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Username or Password is not valid");
            }
        }
    }
}
