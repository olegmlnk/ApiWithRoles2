using ApiWithRoles2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ApiWithRoles2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            throw new NotImplementedException();
        }

    }
}
