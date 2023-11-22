using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
