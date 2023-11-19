using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using JobCraft.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Encodings.Web;

namespace JobCraft.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly UserManager<User> _userManager;
        private readonly EmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;
        public AuthorizationController(AppDbContext dbContext, IUserAuthenticationService userAuthenticationService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, EmailService emailService, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userAuthenticationService = userAuthenticationService;
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
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
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                // Handle user not found

                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                // Email confirmed successfully, log in the user
                await _signInManager.SignInAsync(user, isPersistent: false);
                TempData["Alert"] = "შენი მეილი დადასტურებულია!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle confirmation failure
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAuthenticationService.RegisterAsync(model.RegistrationModel);

                if (result.StatusCode == 1)
                {
                    var user = await _userManager.FindByEmailAsync(model.RegistrationModel.Email);

                    if (user != null)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authorization", new { token, email = user.Email }, _httpContextAccessor.HttpContext.Request.Scheme);
                        var clickHere = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>";

                        await _emailService.SendEmailAsync( user.Email, "Confirmation email link", clickHere);

                        TempData["msgRegister"] = result.Message;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["msgRegister"] = result.Message;
                    return View("Index", model);
                }
            }

            return View("Index", model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAuthenticationService.LoginAsync(model.LoginModel);
                if (result.StatusCode == 1)
                {
                    return RedirectToAction("", "Home");
                }
                else
                {
                    TempData["msgLogin"] = result.Message;
                    return RedirectToAction("Index");
                }
                
            }

            return View("Index", model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return Json(new { success = false, error = "This user does not exist!" });
            }

            return Json(new { success = true });
        }

        public async Task<IActionResult> Logout()
        {
            await _userAuthenticationService.LogOutAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
