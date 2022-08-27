using QuoraForPucit.Models.Interfaces;

namespace QuoraForPucit.Models.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        static int skipnum = 0;
        public void AddQuestion(Question q)
        {
            var context = new QuoraForPucit_DBContext();
            context.Questions.Add(q);
            context.SaveChanges();
        }
        public List<Question> GetAllQuestions(bool check)
        {
            if (check == false)
            {
                skipnum = 0;
            }
            var context = new QuoraForPucit_DBContext();
            List<Question> qs = context.Questions.Skip(skipnum).Take(10).ToList();
            skipnum += 10;
            return qs;
        }
        public Question GetQuestionById(int Id)
        {
            var context = new QuoraForPucit_DBContext();
            var q = context.Questions.Find(Id);
            return q;
        }
        public void VoteQuestion(int questionid, int value)
        {
            var context = new QuoraForPucit_DBContext();
            Question q = context.Questions.Find(questionid);
            if (value == 1)
            {
                q.Upvote = q.Upvote + 1;
            }
            else
            {
                q.Upvote = q.Upvote - 1;
            }
            context.SaveChanges();
        }
    }
}
