using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using Register_A_Person_In_A_Database_Backend_.Models;

namespace Register_A_Person_In_A_Database_Backend_.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user, string password);
        Task<User> FindUserByNameAsync(string username);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> EnsureRoleExistsAndAssignToUserAsync(User user, Roles role);
        Task LogoutAsync();
    }
}
