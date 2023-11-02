using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JobCraft.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInamanger;

        public UserAuthenticationService(UserManager<User> userManager, SignInManager<User> signInamanger)
        {
            _userManager = userManager;
            _signInamanger = signInamanger;
        }

        public Task<IActionResult> LoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RegisterAsync(RegistrationModel model)
        {
            throw new NotImplementedException();
        }
    }
}
