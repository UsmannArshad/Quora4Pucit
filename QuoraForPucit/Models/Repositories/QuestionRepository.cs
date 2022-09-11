using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models;

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
        public void DeleteQuestion(int questionid)
        {
            var context = new QuoraForPucit_DBContext();
            IList<Answer> answers = context.Answers.Where(x => x.QuestionId == questionid).ToList();
            context.Answers.RemoveRange(answers);
            IList<QComment> comments=context.QComments.Where(x=>x.QuestionId == questionid).ToList();
            context.QComments.RemoveRange(comments);
            IList<QuestionsUpvoter> upvoters=context.QuestionsUpvoters.Where(x=>x.QuestionId==questionid).ToList();
            context.QuestionsUpvoters.RemoveRange(upvoters);
            Question q=context.Questions.Find(questionid);
            context.Questions.Remove(q);
            context.SaveChanges();
        }
        public List<Question> SearchQuestion(string category,string searchval)
        {
            var context=new QuoraForPucit_DBContext();
            List<Question> q = new List<Question>();
            if(category=="All")
            {
                if(searchval==null)
                {
                    q = context.Questions.ToList();
                }
                else
                {
                    q = context.Questions.Where(q => q.Title.Contains(searchval)).ToList();
                }

            }
            else if(searchval==null)
            {
                q = context.Questions.Where(q =>q.Subject == category).ToList();
            }
            else
            {
                q= context.Questions.Where(q => q.Title.Contains(searchval) && q.Subject==category).ToList();
            }
            return q;
        }
    }
}
