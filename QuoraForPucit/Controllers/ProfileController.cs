using Microsoft.AspNetCore.Mvc;
using System.IO;
using QuoraForPucit.Models;
using QuoraForPucit.Models.ViewModel;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models.Data;

namespace QuoraForPucit.Controllers
{
    public class ProfileController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IUserRepository _userRepository;
        public ProfileController(IWebHostEnvironment enviroment, IUserRepository ur)
        {
            _webHostEnvironment = enviroment;
            _userRepository = ur;
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
    }
}
