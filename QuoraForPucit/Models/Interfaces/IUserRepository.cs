using QuoraForPucit.Models.ViewModel;
namespace QuoraForPucit.Models.Interfaces
{
    public interface IUserRepository
    {
        public void AddUser(User u);
        public bool IsUsernamenotUnique(string username);
        public bool CheckCredentials(string username, string pwd);
        public User GetUserByUsername(string username);
        public User GetUserById(int id);
        public User UpdateProfile(UserViewModel newuser, int id);
        public bool CheckCredsOfSpecificId(int id, string username, string pwd);
        public int GetQuestionCount(int id);    
        public int GetAnswerCount(int id);
        public List<Question> GetSomeQuestionOfUser(int id);
        public List<User> GetAllUsers();
        public void DeleteUser(int id);

    }
}
