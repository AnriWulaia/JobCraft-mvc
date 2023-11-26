using JobCraft.Models;
using JobCraft.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    [AuthorizeProfile]
    public class ProfileController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;

        public ProfileController(IVacancyService vacancyService, UserManager<User> userManager, IFileService fileService)
        {
            _vacancyService = vacancyService;
            _userManager = userManager;
            _fileService = fileService;
        }

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
        public async Task<IActionResult> AddVacancy(Vacancy model)
        {
            if (!ModelState.IsValid)
            {
                return View("VakansiisDamateba", model);
            }
            var user = await _userManager.GetUserAsync(User);
            model.UserId = user.Id;
            model.CreatedAt = DateTime.Today;
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    model.LogoName = null;
                }
                else
                {
                    var imageName = fileResult.Item2;
                    model.LogoName = imageName;
                }
            }
            _vacancyService.addVacancy(model);
            return View("Index");
            
            
        }
    }
}
