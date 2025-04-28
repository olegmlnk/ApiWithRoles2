using Microsoft.AspNetCore.Identity;

namespace ApiWithRoles2.Domain.Models
{
    public class ApplicationUser
    {
        private ApplicationUser(long id, string username, string email, string passwordHash)
        {
            Id = id;
            UserName = username;
            Email = email;
            PasswordHash = passwordHash;
        }
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;


        public static ApplicationUser Create(long id, string username, string email, string passwordHash)
        {
            return new ApplicationUser(id, username, email, passwordHash);

        }
    }
}
