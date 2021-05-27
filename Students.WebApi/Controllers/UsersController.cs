using System.Threading.Tasks;
using InvestmentApp.Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Shared;

namespace Students.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(Login login)
        {
            var appUser = await UserManager.Users.FirstOrDefaultAsync(u => u.UserName == login.Username);
            if (appUser != null)
            {
                await SignInManager.SignOutAsync();
                var result = await SignInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(TokenService.GenerateToken(appUser));
                }
            }
            return Unauthorized("Invalid credentials.");
        }
    }
}
