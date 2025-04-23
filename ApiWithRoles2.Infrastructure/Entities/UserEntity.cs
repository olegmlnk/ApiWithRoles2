using Microsoft.AspNetCore.Identity;

namespace ApiWithRoles2.Infrastructure.Entities
{
    public class UserEntity : IdentityUser<long>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
    }
}
