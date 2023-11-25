using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace JobCraft.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ვაკანსიის დასახელება აუცილებელია!")]
        [StringLength(30, ErrorMessage = "დასაშვები სიგრძე არის 30!")]
        [Display(Name ="ვაკანსიის დასახელება")]
        public string VacancyName { get; set; }
        [Required(ErrorMessage = "კომპანიის სახელი აუცილებელია!")]
        [StringLength(20, ErrorMessage = "დასაშვები სიგრძე არის 20!")]
        [Display(Name = "კომპანიის სახელი")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "სამუშაოს მდებარეობა აუცილებელია!")]
        [Display(Name = "მდებარეობა")]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "ვაკანსიის ბოლო ვადა აუცილებელია!")]
        [Display(Name = "ვაკანსიის ბოლო ვადა")]
        public DateTime EndsAt { get; set; }
        [Required(ErrorMessage = "კომპანიის მეილი აუცილებელია!")]
        [Display(Name = "კომპანიის მეილი")]
        public string Email { get; set; }
        [Required(ErrorMessage = "კომპანიის ტელეფონის ნომერი აუცილებელია!")]
        [Display(Name = "ტელეფონის ნომერი")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "ვაკანსიის აღწერა აუცილებელია!")]
        [Display(Name = "აღწერა")]
        [AllowHtml]
        public string Content { get; set; }
        public string? LogoName { get; set; } // Image Name with extension
        [NotMapped]
        [Display(Name = "კომპანიის ლოგო")]
        public IFormFile? ImageFile { get; set; }
        public int? UserId { get; set; }
    }
}
