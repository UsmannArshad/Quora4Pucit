using Microsoft.AspNetCore.Mvc;

namespace QuoraForPucit.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
