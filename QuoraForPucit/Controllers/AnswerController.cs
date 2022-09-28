using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models;
using QuoraForPucit.Models.ViewModel;
using QuoraForPucit.Models.Data;
namespace QuoraForPucit.Controllers
{
    public class AnswerController : Controller
    {
        private IQuestionUpvoterRepository _questionUpvoterRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionCommentsRepository _questionCommentsRepository;
        private IAnswerRepository _answerRepository;
        public AnswerController(IQuestionUpvoterRepository questionUpvoterRepository, IQuestionRepository questionRepository, IQuestionCommentsRepository questionCommentsRepository, IAnswerRepository answerRepository)
        {
            _questionUpvoterRepository = questionUpvoterRepository;
            _questionRepository = questionRepository;
            _questionCommentsRepository = questionCommentsRepository;
            _answerRepository = answerRepository;
        }
        [HttpGet]
        public ViewResult GiveAnswer(int id,string wese)
        {
            Question q = _questionRepository.GetQuestionById(id);
            List<Answer> a = _answerRepository.GetAnswersbyQid(id);
            List<QComment> qc = _questionCommentsRepository.GetCommentsbyQid(id);
            ViewData["Question"] = q;
            ViewData["Answers"] = a;
            ViewData["QuestionComments"] = qc;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View();
        }
        [HttpPost]
        public ViewResult GiveAnswer(int id)
        {
            Question q = _questionRepository.GetQuestionById(id);
            List<Answer> a = _answerRepository.GetAnswersbyQid(id);
            List<QComment> qc = _questionCommentsRepository.GetCommentsbyQid(id);
            ViewData["Question"] = q;
            ViewData["Answers"] = a;
            ViewData["QuestionComments"] = qc;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View();
        }
        [HttpPost]
        public IActionResult WriteAnswer(CombinedModel model)
        {
            var cookie = Request.Cookies["Username"];
            if (cookie == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            Answer a = model.answer;
            _answerRepository.AddAnswer(a);
            List<Answer> answerList = _answerRepository.GetAnswersbyQid(a.QuestionId);
            Question q = _questionRepository.GetQuestionById(a.QuestionId);
            List<QComment> qc = _questionCommentsRepository.GetCommentsbyQid(a.QuestionId);
            ViewData["Question"] = q;
            ViewData["Answers"] = answerList;
            ViewData["QuestionComments"] = qc;
            ViewData["CurrentUserId"] = Data.UserId;
            ViewData["Name"] = Data.Name;
            return View("GiveAnswer");
        }
    }
}
