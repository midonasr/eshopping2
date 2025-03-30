using Microsoft.AspNetCore.Mvc;
using Products.Application.Models;
using Products.Application.Services;
using System.Net;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, ILogger<ProductsController> logger)
        {
            _authService = authService;
            _logger = logger;
            _logger.LogInformation("Controller :", "Auth Action");
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(UserDto userForRegisterDto)
        {
            var createdUser = await _authService.Register(userForRegisterDto.userName, userForRegisterDto.password);
            if (!createdUser)
                return BadRequest("Username already exists");

            return Ok(createdUser);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login(UserDto userForLoginDto)
        {
            var token = await _authService.Login(userForLoginDto.userName, userForLoginDto.password);
            if (token == null)
                return Unauthorized();
            return Ok(new { token = token });
        }

    }
}
