using Microsoft.AspNetCore.Identity;
using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using Register_A_Person_In_A_Database_Backend_.Data.Interfaces;
using Register_A_Person_In_A_Database_Backend_.Models;

namespace Register_A_Person_In_A_Database_Backend_.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<User> CreateUserAsync(User user, string password)
        {
            // Create a new user in the system with the specified password

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task<User> FindUserByNameAsync(string username)
        {
            // Find a user by their username

            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            // Check if the provided password matches the user's password

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> EnsureRoleExistsAndAssignToUserAsync(User user, Roles role)
        {
            // Ensure a role exists and assign it to a user

            var roleExists = await _roleManager.RoleExistsAsync(role.ToString());
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, role.ToString());
            return roleResult.Succeeded;
        }

        public async Task LogoutAsync()
        {
            // Sign the user out

            await _signInManager.SignOutAsync();
        }
    }
}
