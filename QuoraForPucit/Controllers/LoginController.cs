using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models;
using QuoraForPucit.Models.Data;
using Microsoft.AspNetCore.Identity;

namespace QuoraForPucit.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionUpvoterRepository _questionUpvoterRepository;
        private readonly UserManager<UserwithIdentity> _userManager;
        private readonly SignInManager<UserwithIdentity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public LoginController(IUserRepository userRepository, IQuestionRepository questionRepository,IQuestionUpvoterRepository questionUpvoterRepository,UserManager<UserwithIdentity> userManager,SignInManager<UserwithIdentity> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _questionUpvoterRepository = questionUpvoterRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                return View("DeniedLogin");
            }
            else
            {
                var passwordcheck = await _userManager.CheckPasswordAsync(user, password);
                if (passwordcheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, password,true, false);
                    if (result.Succeeded)
                    {
                        User u = _userRepository.GetUserByUsername(username);
                        Data.UserId = u.Id;
                        Data.Name = u.Name;
                        Data.UserName = u.Username;
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddDays(365);
                        HttpContext.Response.Cookies.Append("Username", u.Username, options);
                        HttpContext.Response.Cookies.Append("Name", u.Name, options);
                        HttpContext.Response.Cookies.Append("Id", u.Id.ToString(), options);
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
                        ViewData["Username"] = Data.UserName;
                        return RedirectToAction("MainPage","Question");
                    }
                }
            }
            return View("DeniedLogin");
            /*bool check = _userRepository.CheckCredentials(username, password);
            if (check == true)
            {
                User u = _userRepository.GetUserByUsername(username);
                Data.UserId = u.Id;
                Data.Name = u.Name;
                Data.UserName = u.Username;
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(365);
                HttpContext.Response.Cookies.Append("Username", u.Username, options);
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
                ViewData["Username"] = Data.UserName;
                return View("../Question/MainPage");
            }
            else
            {
                return View("DeniedLogin");
            }*/
        }
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var user1 = await _userManager.FindByEmailAsync(user.Username);
                if (user1 != null)
                {
                    return View("DeniedSignUp");
                }
                var newUser = new UserwithIdentity()
                {
                    Name = user.Name,
                    Email = user.Username,
                    UserName = user.Username,
                    Age = user.Age,
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, user.Password);
                _userRepository.AddUser(user);
                if (newUserResponse.Succeeded)
                {
                    if (user.Username == "admin@gmail.com")
                    {
                        var roleExist = await _roleManager.RoleExistsAsync("Admin");
                        if (!roleExist)
                        {
                            var roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                                Console.WriteLine(error.Description);
                            }
                        }
                        await _userManager.AddToRoleAsync(newUser, "Admin");
                        await _signInManager.PasswordSignInAsync(newUser, user.Password, false, false);
                    }
                    else
                    {
                        var roleExist = await _roleManager.RoleExistsAsync("User");
                        if (!roleExist)
                        {
                            var roleResult = await _roleManager.CreateAsync(new IdentityRole("User"));
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                                Console.WriteLine(error.Description);
                            }
                        }
                        await _userManager.AddToRoleAsync(newUser, "User");
                        await _signInManager.PasswordSignInAsync(newUser, user.Password, false, false);
                    }
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
                    ViewData["Username"] = Data.UserName;
                    ViewData["ListofQuestion"] = listofqs;
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(365);
                    HttpContext.Response.Cookies.Append("Username", u.Username, options);
                    HttpContext.Response.Cookies.Append("Name", u.Name, options);
                    HttpContext.Response.Cookies.Append("Id", u.Id.ToString(), options);
                    return RedirectToAction("MainPage","Question");


                }
                else
                {
                    foreach (var error in newUserResponse.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        Console.WriteLine(error.Description);
                    }
                    return View();
                }
                /*bool check = _userRepository.IsUsernamenotUnique(user.Username);
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
                    ViewData["Username"] = Data.UserName;
                    ViewData["ListofQuestion"] = listofqs;
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(365);
                    HttpContext.Response.Cookies.Append("Username", u.Username, options);
                    return View("../Question/MainPage");
                }*/
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            var cookie = Request.Cookies["Username"];
            if (cookie == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            Response.Cookies.Delete("Username");
            await _signInManager.SignOutAsync();
            return RedirectToAction("MainPage","Question");
        }
    }
}
