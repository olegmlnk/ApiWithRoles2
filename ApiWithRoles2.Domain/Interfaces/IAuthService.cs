using ApiWithRoles2.Domain.Models;

namespace ApiWithRoles2.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, IEnumerable<string> Errors)> Register(string username, string email, string password);
        Task<(bool Success, string Token, string Error)> Login(string username, string password);
        string GenerateJwtToken(ApplicationUser user);
    }
}
