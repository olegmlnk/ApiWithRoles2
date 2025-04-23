using ApiWithRoles2.Infrastructure.Configurations;
using ApiWithRoles2.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithRoles2.Infrastructure
{
    public class AppDbContext : IdentityDbContext<UserEntity, IdentityRole<long>, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
        }

    }

}