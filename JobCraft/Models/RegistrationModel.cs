using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobCraft.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [MaxLength(20, ErrorMessage = "First Name should be at most 20 characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "Last Name should be at most 20 characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase, 1 lowercase, 1 special character, and 1 digit")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "The Confirm Password field must match the Password field")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }


    }
}
