using System.ComponentModel.DataAnnotations;

namespace JobCraft.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="ვაკანსიის დასახელება")]
        public string VacancyName { get; set; }
        [Required]
        [Display(Name = "აღწერა")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "კომპანიის სახელი")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "მდებარეობა")]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [Display(Name = "ვაკანსიის ბოლო ვადა")]
        public DateTime EndsAt { get; set; }
        [Required]
        [Display(Name = "კომპანიის მეილი")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "ტელეფონის ნომერი")]
        public string Phone { get; set; }
        public int? UserId { get; set; }
    }
}
