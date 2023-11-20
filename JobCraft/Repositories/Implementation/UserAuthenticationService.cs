using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Text.Encodings.Web;

namespace JobCraft.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailService _emailService;
        private readonly AppDbContext _dbContext;

        public UserAuthenticationService(UserManager<User> userManager, SignInManager<User> signInamanger, AppDbContext dbContext, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInamanger;
            _dbContext = dbContext;
            _emailService = emailService;
        }

        public async Task<Status> LoginAsync(LoginModel model)
        {
            var status = new Status();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "User does not exist!";
                return status;
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Incorrect password or email!";
                return status;
            }
            bool isRemembered = model.RememberMe;
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isRemembered, true);
            if (signInResult.Succeeded)
            {
                status.StatusCode = 1;
                status.Message = "Successful";
                return status;
            }

            return status;
        }
        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<Status> RegisterAsync(RegistrationModel model)
        {
            var status = new Status();
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exists!";
                return status;
            }

            var user = new User
            {
                Firstname = model.FirstName,
                Lastname = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(), // Generate a unique security stamp
                EmailConfirmed = false,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                status.StatusCode = 1;
                status.Message = "You have been registered successfully! Please check your email to confirm your registration.";
                return status;
                
            }

            status.StatusCode = 0;
            status.Message = "There was an error.";
            return status;
        }


    }
}
