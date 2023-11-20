using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobCraft.Models
{
    public class ResetPasswordModel
    {
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
