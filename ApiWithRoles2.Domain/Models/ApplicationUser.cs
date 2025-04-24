using Microsoft.AspNetCore.Identity;

namespace ApiWithRoles2.Domain.Models
{
    public class ApplicationUser : IdentityUser<long>
    { 
        public string FullName { get; set; } = string.Empty;
    }
}
