using JobCraft.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace JobCraft.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<bool> LoginAsync(LoginModel model);
        Task LogOutAsync();
        Task<bool> RegisterAsync(RegistrationModel model);
    }
}
