using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models.ViewModel;
using System.IO;

namespace QuoraForPucit.Controllers
{
    public class UserController : Controller
    {
        [Route("/User/AboutUs", Name = "aboutuss")]
        public ViewResult AboutUs()
        {
            return View();
        }
        [Route("/User/ContactUs", Name = "contactuss")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
