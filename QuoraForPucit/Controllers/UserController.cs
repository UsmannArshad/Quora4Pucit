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
        [Route("/User/MainPage", Name = "usermainpage")]
        public ViewResult MainPage()
        {
            return View();
        }
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
        [Route("/User/EditProfile", Name = "editprofile")]
        public ViewResult EditProfile()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AskQuestion()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AskQuestion(Question q)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("nice");
                return View();
            }
            else
            {
                Console.WriteLine("not nice");
                return View();
            }
        }
        public ViewResult Profile()
        {
            return View();
        }
        public ViewResult GiveAnswer()
        {
            return View();
        }
    }
}
