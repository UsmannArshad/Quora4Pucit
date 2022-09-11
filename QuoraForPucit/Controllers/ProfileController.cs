using Microsoft.AspNetCore.Mvc;
using System.IO;
using QuoraForPucit.Models;
using QuoraForPucit.Models.ViewModel;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models.Data;
using AutoMapper;

namespace QuoraForPucit.Controllers
{
    public class ProfileController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public ProfileController(IWebHostEnvironment enviroment, IUserRepository ur,IMapper mapper)
        {
            _webHostEnvironment = enviroment;
            _userRepository = ur;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("/Profile/EditProfile", Name = "editprofile")]
        public ViewResult EditProfile()
        {
            User u = _userRepository.GetUserByUsername(Data.UserName);
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
        public ViewResult Profile()
        {
            User u = _userRepository.GetUserByUsername(Data.UserName);
            ViewData["User"] = u;
            return View();
        }
        public IActionResult CheckPrevCreds(int id,string email,string pwd)
        {
            bool check=_userRepository.CheckCredsOfSpecificId(id, email, pwd);
            if (check == true)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }
        public IActionResult GetAllUsers()
        {
            List<User> users=_userRepository.GetAllUsers();
            List<UserShowViewModel> usersmappedlist=new List<UserShowViewModel>();
            foreach(User user in users)
            {
                UserShowViewModel usersmapped = _mapper.Map<UserShowViewModel>(user);
                usersmappedlist.Add(usersmapped);
            }

            return View("ManageUsers",usersmappedlist);
        }
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction("GetAllUsers", "Profile");
        }
    }
}
