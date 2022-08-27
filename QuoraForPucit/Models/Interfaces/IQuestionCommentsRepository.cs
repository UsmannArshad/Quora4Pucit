namespace QuoraForPucit.Models.Interfaces
{
    public interface IQuestionCommentsRepository
    {
        public void AddComment(QComment qc);
        public List<QComment> GetCommentsbyQid(int id);
    }
}
