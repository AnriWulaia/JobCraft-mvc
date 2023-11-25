using JobCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    [AuthorizeProfile]
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("[controller]/vakansiis-damateba")]
        public IActionResult VakansiisDamateba()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVacancyAsync(Vacancy model)
        {
            if (!ModelState.IsValid)
            {
                return View("VakansiisDamateba", model);
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}
