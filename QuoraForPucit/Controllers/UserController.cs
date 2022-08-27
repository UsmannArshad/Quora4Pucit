using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models.ViewModel;
using System.IO;

namespace QuoraForPucit.Controllers
{
    public class UserController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IUserRepository _userRepository;
        private IQuestionUpvoterRepository _questionUpvoterRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionCommentsRepository _questionCommentsRepository;
        private IAnswerRepository _answerRepository;
        public UserController(IWebHostEnvironment enviroment, IUserRepository ur, IQuestionUpvoterRepository questionUpvoterRepository, IQuestionRepository questionRepository, IQuestionCommentsRepository questionCommentsRepository, IAnswerRepository answerRepository)
        {
            _webHostEnvironment = enviroment;
            _userRepository = ur;
            _questionUpvoterRepository = questionUpvoterRepository;
            _questionRepository = questionRepository;
            _questionCommentsRepository = questionCommentsRepository;
            _answerRepository = answerRepository;
        }
        static int UserId = 0;
        static string Name = "";
        static string UserName = "";
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
                UserId = u.Id;
                Name = u.Name;
                UserName = u.Username;
                List<Question> listofqs = _questionRepository.GetAllQuestions(false);
                ViewData["ListofQuestion"] = listofqs;
                List<int> listofupvotestatus = new List<int>();
                foreach (Question q in listofqs)
                {
                    int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, UserId);
                    listofupvotestatus.Add(status);
                }
                ViewData["ListOfQuestionStatus"] = listofupvotestatus;
                ViewData["CurrentUserId"] = UserId;
                ViewData["Name"] = Name;
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
                    UserId = u.Id;
                    Name = u.Name;
                    UserName = u.Username;
                    List<Question> listofqs = _questionRepository.GetAllQuestions(false);
                    List<int> listofupvotestatus = new List<int>();
                    foreach (Question q in listofqs)
                    {
                        int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, UserId);
                        listofupvotestatus.Add(status);
                    }
                    ViewData["ListOfQuestionStatus"] = listofupvotestatus;
                    ViewData["CurrentUserId"] = UserId;
                    ViewData["Name"] = Name;
                    ViewData["ListofQuestion"] = listofqs;
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
            List<Question> listofqs = _questionRepository.GetAllQuestions(false);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View();
        }
        public ViewResult LoadMore()
        {
            List<Question> listofqs = _questionRepository.GetAllQuestions(true);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View("MainPage");
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
        [HttpGet]
        [Route("/User/EditProfile", Name = "editprofile")]
        public ViewResult EditProfile()
        {
            Console.WriteLine(UserName);
            User u = _userRepository.GetUserByUsername(UserName);
            ViewData["User"] = u;
            return View();
        }
        [HttpPost]
        public ViewResult EditProfile(UserViewModel newuser)
        {
            if (newuser.ProfilePicture != null)
            {
                string filename = "images/Uploads/" + newuser.Id.ToString() + ".png";
                string Serverfilename = Path.Combine(_webHostEnvironment.WebRootPath, filename);
                /*    if(System.IO.File.Exists(Serverfilename))
                    {
                        Console.WriteLine("happy");
                        System.IO.File.Delete(Serverfilename);
                    }*/
                FileStream f = new FileStream(Serverfilename, FileMode.Create);
                newuser.ProfilePicture.CopyTo(f);
                f.Close();
                newuser.PicturePath = filename;
            }
            User updateduser = _userRepository.UpdateProfile(newuser, newuser.Id);
            ViewData["User"] = updateduser;
            return View();
        }
        [HttpGet]
        public ViewResult AskQuestion()
        {
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View();
        }
        [HttpPost]
        public ViewResult AskQuestion(Question q)
        {
            _questionRepository.AddQuestion(q);
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View();
        }
        public ViewResult Profile()
        {
            User u = _userRepository.GetUserByUsername(UserName);
            ViewData["User"] = u;
            return View();
        }
        [HttpPost]
        public ViewResult GiveAnswer(int Id)
        {
            Question q = _questionRepository.GetQuestionById(Id);
            List<Answer> a = _answerRepository.GetAnswersbyQid(Id);
            List<QComment> qc = _questionCommentsRepository.GetCommentsbyQid(Id);
            ViewData["Question"] = q;
            ViewData["Answers"] = a;
            ViewData["QuestionComments"] = qc;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View();
        }
        [HttpPost]
        public ViewResult WriteAnswer(CombinedModel model)
        {
            Answer a = model.answer;
            _answerRepository.AddAnswer(a);
            List<Answer> answerList = _answerRepository.GetAnswersbyQid(a.QuestionId);
            Question q = _questionRepository.GetQuestionById(a.QuestionId);
            List<QComment> qc = _questionCommentsRepository.GetCommentsbyQid(a.QuestionId);
            ViewData["Question"] = q;
            ViewData["Answers"] = answerList;
            ViewData["QuestionComments"] = qc;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View("GiveAnswer");
        }
        [HttpPost]
        public ViewResult AddCommentToQuestion(CombinedModel model)
        {
            QComment qc = model.qcomment;
            _questionCommentsRepository.AddComment(qc);
            List<Answer> answerList = _answerRepository.GetAnswersbyQid(qc.QuestionId);
            Question q = _questionRepository.GetQuestionById(qc.QuestionId);
            List<QComment> qc1 = _questionCommentsRepository.GetCommentsbyQid(qc.QuestionId);
            ViewData["Question"] = q;
            ViewData["Answers"] = answerList;
            ViewData["QuestionComments"] = qc1;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View("GiveAnswer");
        }
        [HttpPost]
        public ViewResult VoteQuestion(int questionid, int votevalue)
        {
            _questionRepository.VoteQuestion(questionid, votevalue);
            QuestionsUpvoter qu = new QuestionsUpvoter();
            qu.UpvoteStatus = votevalue;
            qu.UserId = UserId;
            qu.QuestionId = questionid;
            _questionUpvoterRepository.Managevoter(qu);
            List<Question> listofqs = _questionRepository.GetAllQuestions(false);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = UserId;
            ViewData["Name"] = Name;
            return View("MainPage");
        }
    }
}
