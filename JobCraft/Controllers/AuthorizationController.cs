using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace JobCraft.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AuthorizationController(AppDbContext dbContext, IUserAuthenticationService userAuthenticationService)
        {
            _dbContext = dbContext;
            _userAuthenticationService = userAuthenticationService;
        }
        public IActionResult Index()
        {
            var viewModel = new LoginRegisterViewModel
            {
                LoginModel = new LoginModel(),
                RegistrationModel = new RegistrationModel()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAuthenticationService.RegisterAsync(model.RegistrationModel);
                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAuthenticationService.LoginAsync(model.LoginModel);
                if (result)
                {
                    return RedirectToAction("", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }

            return View("Index", model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userAuthenticationService.LogOutAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
