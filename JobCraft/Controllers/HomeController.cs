using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using JobCraft.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobCraft.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVacancyService _vacancyService;

        public HomeController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public IActionResult Index()
        {
            var vacancies = _vacancyService.List();
            return View(vacancies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("job/{id:int}", Name = "jobdesc")]
        public async Task<IActionResult> JobDetails(int id)
        {
            var vacancy = _vacancyService.getById(id);
            return View(vacancy);
        }
    }
}