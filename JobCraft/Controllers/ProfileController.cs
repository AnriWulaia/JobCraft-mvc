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
        [Route("[controller]/gancxadebis-damateba")]
        public IActionResult VakansiisDamateba()
        {
            return View();
        }
    }
}
