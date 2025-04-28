using ApiWithRoles2.Domain.Interfaces;
using ApiWithRoles2.Domain.Models;
using ApiWithRoles2.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiWithRoles2.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddUser(ApplicationUser user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };

            await _appDbContext.Users.AddAsync(userEntity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            var userEntity  = await _appDbContext.Users.FindAsync(user);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            _appDbContext.Users.Remove(userEntity); 
            await _appDbContext.SaveChangesAsync();
        }

        public Task<bool> UserExistsByEmail(string email)
        {
            var userEntity = _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email); 

            if (userEntity == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> UserExistsByUsername(string username)
        {
            var userEntity = _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (userEntity == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            //var users = _appDbContext.Users
            //    .Select(x => new ApplicationUser
            //    {
            //        Id = x.Id,
            //        UserName = x.UserName,
            //        Email = x.Email,
            //        PasswordHash = x.PasswordHash
            //    });

            throw new NotImplementedException();
        }

        public async Task<ApplicationUser?> GetUserByEmail(string email)
        {
            var userEntity = await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            
        }

        public Task<ApplicationUser?> GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
