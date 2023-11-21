using Microsoft.AspNetCore.Mvc;

namespace JobCraft.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
