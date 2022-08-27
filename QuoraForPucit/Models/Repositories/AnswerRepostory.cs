using QuoraForPucit.Models.Interfaces;

namespace QuoraForPucit.Models.Repositories
{
    public class AnswerRepostory : IAnswerRepository
    {
        public void AddAnswer(Answer a)
        {
            var db = new QuoraForPucit_DBContext();
            db.Answers.Add(a);
            db.SaveChanges();
        }
        public List<Answer> GetAnswersbyQid(int id)
        {

            var db = new QuoraForPucit_DBContext();
            List<Answer> ans = db.Answers.Where(ans => ans.QuestionId == id).ToList();
            return ans;
        }
    }
}
