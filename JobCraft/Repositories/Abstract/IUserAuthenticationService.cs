using JobCraft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace JobCraft.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<IActionResult> LoginAsync(LoginModel model);
        Task LogOutAsync();
        Task<IActionResult> RegisterAsync(RegistrationModel model);
    }
}
