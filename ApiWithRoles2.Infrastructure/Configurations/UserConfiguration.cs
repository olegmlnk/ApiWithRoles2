using ApiWithRoles2.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWithRoles2.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
