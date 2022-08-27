using QuoraForPucit.Models.Interfaces;

namespace QuoraForPucit.Models.Repositories
{
    public class QuestionUpvoterRepository : IQuestionUpvoterRepository
    {
        public int GetUpvoteStatus(int qsid, int userid)
        {
            var context = new QuoraForPucit_DBContext();
            bool check = context.QuestionsUpvoters.Any(a => a.QuestionId == qsid && a.UserId == userid);
            if (check == true)
            {
                QuestionsUpvoter qu = context.QuestionsUpvoters.Where(a => a.QuestionId == qsid && a.UserId == userid).FirstOrDefault();
                return qu.UpvoteStatus;
            }
            else
            {
                return 0;
            }
        }
        public void Managevoter(QuestionsUpvoter qu)
        {
            var context = new QuoraForPucit_DBContext();
            bool check = context.QuestionsUpvoters.Any(a => a.QuestionId == qu.QuestionId && a.UserId == qu.UserId);
            if (check == true)
            {
                QuestionsUpvoter qu1 = context.QuestionsUpvoters.Where(a => a.QuestionId == qu.QuestionId && a.UserId == qu.UserId).FirstOrDefault();
                context.QuestionsUpvoters.Remove(qu1);
                context.SaveChanges();
            }
            else
            {
                context.QuestionsUpvoters.Add(qu);
            }
            context.SaveChanges();

        }
    }
}
