using QuoraForPucit.Models.ViewModel;
using QuoraForPucit.Models.Interfaces;

namespace QuoraForPucit.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User u)
        {
            var context = new QuoraForPucit_DBContext();
            context.Users.Add(u);
            context.SaveChanges();
        }
        public bool IsUsernamenotUnique(string username)
        {
            var context = new QuoraForPucit_DBContext();
            bool chek = context.Users.Any(u => u.Username == username);
            return chek;
        }
        public bool CheckCredentials(string username, string pwd)
        {
            var context = new QuoraForPucit_DBContext();
            bool chek = context.Users.Any(u => u.Username == username && u.Password == pwd);
            return chek;
        }
        public User GetUserByUsername(string username)
        {
            var context = new QuoraForPucit_DBContext();
            User u = context.Users.Where(a => a.Username == username).Single();
            return u;
        }
        public User GetUserById(int id)
        {
            var context = new QuoraForPucit_DBContext();
            User u = context.Users.Find(id);
            return u;
        }
        public User UpdateProfile(UserViewModel newuser, int id)
        {
            var context = new QuoraForPucit_DBContext();
            Console.WriteLine(newuser.PicturePath);
            User olduser = context.Users.Find(id);
            if (newuser.Name != null)
            {
                olduser.Name = newuser.Name;
            }
            if (newuser.Age != 0)
            {
                olduser.Age = newuser.Age;
            }
            if (newuser.About != null)
            {
                olduser.About = newuser.About;
            }
            if (newuser.Twitter != null)
            {
                olduser.Twitter = newuser.Twitter;
            }
            if (newuser.Website != null)
            {
                olduser.Website = newuser.Website;
            }
            if (newuser.Github != null)
            {
                olduser.Github = newuser.Github;
            }
            if (newuser.Username != null)
            {
                olduser.Username = newuser.Username;
            }
            if (newuser.Password != null)
            {
                olduser.Password = newuser.Password;
            }
            if (newuser.PicturePath != null)
            {
                olduser.ProfilePicture = newuser.PicturePath;
            }
            context.SaveChanges();
            return olduser;
        }
    }
}
