namespace QuoraForPucit.Models.Interfaces
{
    public interface IAnswerRepository
    {
        public void AddAnswer(Answer a);
        public List<Answer> GetAnswersbyQid(int id);
    }
}
