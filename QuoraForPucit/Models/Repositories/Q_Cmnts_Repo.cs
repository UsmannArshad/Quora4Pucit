using QuoraForPucit.Models.Interfaces;

namespace QuoraForPucit.Models.Repositories
{
    public class Q_Cmnts_Repo : IQuestionCommentsRepository
    {
        public void AddComment(QComment qc)
        {
            var context = new QuoraForPucit_DBContext();
            context.QComments.Add(qc);
            context.SaveChanges();
        }
        public List<QComment> GetCommentsbyQid(int id)
        {
            var context = new QuoraForPucit_DBContext();
            List<QComment> qc = context.QComments.Where(q => q.QuestionId == id).ToList();
            return qc;
        }
    }
}
