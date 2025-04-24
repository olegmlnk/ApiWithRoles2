using ApiWithRoles2.Domain.Models;

namespace ApiWithRoles2.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserById(long id);
        Task<ApplicationUser?> GetUserByUsername(string username);
        Task<ApplicationUser?> GetUserByEmail(string email);
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task AddUser(ApplicationUser user);
        Task UpdateUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task<bool> UserExistsByUsername(string username);
        Task<bool> UserExistsByEmail(string email);
    }
}
