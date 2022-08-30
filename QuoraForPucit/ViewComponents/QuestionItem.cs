using Microsoft.AspNetCore.Mvc;
using QuoraForPucit.Models;
namespace QuoraForPucit.ViewComponents
{
    public class QuestionItem:ViewComponent
    {
        public IViewComponentResult Invoke(Question q, int index,int status)
        {
            ViewData["Question"] = q;
            ViewData["Index"] = index;
            ViewData["Status"] = status;
            return View();
        }
    }
}
