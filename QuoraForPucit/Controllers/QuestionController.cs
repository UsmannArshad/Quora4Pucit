using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models;
using QuoraForPucit.Models.ViewModel;
using QuoraForPucit.Models.Data;

namespace QuoraForPucit.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionUpvoterRepository _questionUpvoterRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionCommentsRepository _questionCommentsRepository;
        private IAnswerRepository _answerRepository;
        public QuestionController( IQuestionUpvoterRepository questionUpvoterRepository, IQuestionRepository questionRepository, IQuestionCommentsRepository questionCommentsRepository, IAnswerRepository answerRepository)
        {
            _questionUpvoterRepository = questionUpvoterRepository;
            _questionRepository = questionRepository;
            _questionCommentsRepository = questionCommentsRepository;
            _answerRepository = answerRepository;
        }

        [HttpPost]
        public ViewResult AddCommentToQuestion(CombinedModel model)
        {
            QComment qc = model.qcomment;
            _questionCommentsRepository.AddComment(qc);
            List<Answer> answerList = _answerRepository.GetAnswersbyQid(qc.QuestionId);
            Question q = _questionRepository.GetQuestionById(qc.QuestionId);
            List<QComment> qc1 = _questionCommentsRepository.GetCommentsbyQid(qc.QuestionId);
            ViewData["Question"] = q;
            ViewData["Answers"] = answerList;
            ViewData["QuestionComments"] = qc1;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View("../Answer/GiveAnswer");
        }
        [HttpPost]
        public ViewResult VoteQuestion(int questionid, int votevalue)
        {
            _questionRepository.VoteQuestion(questionid, votevalue);
            QuestionsUpvoter qu = new QuestionsUpvoter();
            qu.UpvoteStatus = votevalue;
            qu.UserId = Data.UserId;
            qu.QuestionId = questionid;
            _questionUpvoterRepository.Managevoter(qu);
            List<Question> listofqs = _questionRepository.GetAllQuestions(false);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View("MainPage");
        }
        public ViewResult AskQuestion()
        {
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View();
        }
        [HttpPost]
        public ViewResult AskQuestion(Question q)
        {
            _questionRepository.AddQuestion(q);
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View();
        }
        [Route("/Question/MainPage", Name = "usermainpage")]
        public ViewResult MainPage()
        {
            List<Question> listofqs = _questionRepository.GetAllQuestions(false);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View();
        }
        public ViewResult LoadMore()
        {
            List<Question> listofqs = _questionRepository.GetAllQuestions(true);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View("MainPage");
        }
        public IActionResult DeleteQuestion(int Id)
        {
            _questionRepository.DeleteQuestion(Id);
            return RedirectToAction("MainPage", "Question");
        }
        [HttpPost]
        public IActionResult SearchQuestion(string Category,string searchvalue)
        {
            List<Question> listofqs = _questionRepository.SearchQuestion(Category, searchvalue);
            List<int> listofupvotestatus = new List<int>();
            foreach (Question q in listofqs)
            {
                int status = _questionUpvoterRepository.GetUpvoteStatus(q.Id, Data.UserId);
                listofupvotestatus.Add(status);
            }
            ViewData["ListOfQuestionStatus"] = listofupvotestatus;
            ViewData["ListofQuestion"] = listofqs;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View("MainPage");
        }
    }
}
