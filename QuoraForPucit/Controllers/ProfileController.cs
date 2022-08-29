using Microsoft.AspNetCore.Mvc;

namespace QuoraForPucit.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
