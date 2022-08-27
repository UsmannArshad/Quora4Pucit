namespace QuoraForPucit.Models.Interfaces
{
    public interface IQuestionUpvoterRepository
    {
        public int GetUpvoteStatus(int qsid, int userid);
        public void Managevoter(QuestionsUpvoter qu);
    }
}
