using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Contexts;
using WebApp.Models.Identities;

namespace WebApp.Services
{
    public class UserService
    {

        
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
          
            _userManager = userManager;
        }

        public async Task<IEnumerable<(string email, string firstName, string lastName, string roleName)>> GetAllUsersWithRolesAsync()
        {
            var userAndRole = new List<(string?, string?, string?, string?)>();
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                userAndRole.Add((user.Email, user.FirstName, user.LastName, roleName));
            }

            return userAndRole;
        }

        
    }
}
