namespace QuoraForPucit.Models.Interfaces
{
    public interface IQuestionRepository
    {
        public void AddQuestion(Question q);
        public List<Question> GetAllQuestions(Boolean check);
        public Question GetQuestionById(int Id);
        public void VoteQuestion(int questionid, int value);


    }
}
