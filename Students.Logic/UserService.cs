using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Students.Logic
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> UserManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task<IdentityResult> Create(IdentityUser user, string password)
        {
            return await UserManager.CreateAsync(user, password);
        }
    }
}
