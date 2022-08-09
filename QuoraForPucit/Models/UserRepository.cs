namespace QuoraForPucit.Models
{
    public class UserRepository
    {
        public static void AddUser(User u)
        {
            var context = new QuoraForPucit_DBContext();
            context.Users.Add(u);
            context.SaveChanges();
        }
        public static bool IsUsernamenotUnique(string username)
        {
            var context = new QuoraForPucit_DBContext();
            bool chek = context.Users.Any(u => u.Username == username);
            return chek;
        }
        public static bool CheckCredentials(string username, string pwd)
        {
            var context = new QuoraForPucit_DBContext();
            bool chek = context.Users.Any(u => u.Username == username && u.Password == pwd);
            return chek;
        }
    }
}
