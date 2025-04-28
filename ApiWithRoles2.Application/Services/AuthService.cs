using ApiWithRoles2.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWithRoles2.Application.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        
        public AuthService(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> Register(string username, string email, string password)
        {
            var user = ApplicationUser.Create(0, username, email, password);

            var result = await _userManager.CreateAsync(user, password);

            if(!result.Succeeded)
            {
                return (false, result.Errors.Select(e => e.Description));
            }

            await _userManager.AddToRoleAsync(user, "User");
            return (true, null);
        }

        public async Task<(bool Success, string Token, string Error)> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if(user == null)
                return (false, string.Empty, "Invalid username or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return (false, string.Empty, "Invalid username or password");

            var token = GenerateJwtToken(user);
            return (true, token, string.Empty);
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? "")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Isuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
