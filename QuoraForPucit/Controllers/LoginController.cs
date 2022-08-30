using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models;
using QuoraForPucit.Models.Data;

namespace QuoraForPucit.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionUpvoterRepository _questionUpvoterRepository;
        public LoginController(IUserRepository userRepository, IQuestionRepository questionRepository,IQuestionUpvoterRepository questionUpvoterRepository)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _questionUpvoterRepository = questionUpvoterRepository;
        }
        [HttpGet]
        public ViewResult SignIn()
        {

            return View();
        }
        [HttpPost]
        public ViewResult SignIn(string username, string password)
        {
            bool check = _userRepository.CheckCredentials(username, password);
            if (check == true)
            {
                User u = _userRepository.GetUserByUsername(username);
                Data.UserId = u.Id;
                Data.Name = u.Name;
                Data.UserName = u.Username;
                List<Question> listofqs = _questionRepository.GetAllQuestions(false);
                ViewData["ListofQuestion"] = listofqs;
                List<int> listofupvotestatus = new List<int>();
                foreach (Question q in listofqs)
                {
                    int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                    listofupvotestatus.Add(status);
                }
                ViewData["ListOfQuestionStatus"] = listofupvotestatus;
                ViewData["CurrentUserId"] = Data.UserId;
                ViewData["Name"] = Data.Name;
                return View("../Question/MainPage");
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
        public ViewResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                bool check = _userRepository.IsUsernamenotUnique(user.Username);
                if (check == true)
                {
                    return View("DeniedSignUp");
                }
                else
                {
                    _userRepository.AddUser(user);
                    User u = _userRepository.GetUserByUsername(user.Username);
                    Data.UserId = u.Id;
                    Data.Name = u.Name;
                    Data.UserName = u.Username;
                    List<Question> listofqs = _questionRepository.GetAllQuestions(false);
                    List<int> listofupvotestatus = new List<int>();
                    foreach (Question q in listofqs)
                    {
                        int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                        listofupvotestatus.Add(status);
                    }
                    ViewData["ListOfQuestionStatus"] = listofupvotestatus;
                    ViewData["CurrentUserId"] = Data.UserId;
                    ViewData["Name"] = Data.Name;
                    ViewData["ListofQuestion"] = listofqs;
                    return View("../Question/MainPage");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
