using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    public class JobsListController : Controller
    {
        private readonly IVacancyService _vacancyService;

        public JobsListController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        public IActionResult Index(string title = "", string category = "", string location = "")
        {

            var vacancies = _vacancyService.FilterList(title, category, location);
            return View(vacancies);
        }

    }
}
