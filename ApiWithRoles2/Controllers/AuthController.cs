using ApiWithRoles2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithRoles2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {

        }

        public async Task<IActionResult> Login()
        {

        }

    }
}
