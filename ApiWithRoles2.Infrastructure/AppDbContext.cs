using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ApiWithRoles2.Infrastructure
{
    public class AppDbContext : IdentityDbContext<>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<YourEntity> YourEntities { get; set; }
    }
    {
    }
}
