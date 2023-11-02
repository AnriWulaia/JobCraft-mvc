using JobCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            return View();
        }
    }
}
