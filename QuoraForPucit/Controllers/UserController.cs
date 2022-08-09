using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models;

namespace QuoraForPucit.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignIn(string username,string password)
        {
            bool check = UserRepository.CheckCredentials(username, password);
            if (check == true)
            {
                return View("MainPage");
            }
            else
            {
                return View("DeniedLogin");
            }
        }
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignUp(User u)
        {
            if (ModelState.IsValid)
            {
                bool check = UserRepository.IsUsernamenotUnique(u.Username);
                if (check == true)
                {
                    return View("DeniedSignUp");
                }
                else
                {
                    UserRepository.AddUser(u);
                    return View("MainPage");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
