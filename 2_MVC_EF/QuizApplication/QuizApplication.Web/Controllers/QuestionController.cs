using Microsoft.AspNetCore.Mvc;
using QuizApplication.AppLogic;
using QuizApplication.AppLogic.Contracts;
using QuizApplication.Domain;
using QuizApplication.Web.Models;
using System.Collections.Generic;

namespace QuizApplication.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuizService _quizService;

        public QuestionController(ILogger<QuestionController> logger, IQuizService quizService)
        {
            _logger = logger;
            _quizService = quizService;
        }
        public IActionResult Index()
        {
           
            return View(_quizService.GetAllCategories());
        }

        public IActionResult QuestionsInCategory(int id)
        {
            return View(_quizService.GetQuestionsInCategory(id));
        }

        public IActionResult QuestionWithAnswers(int id)
        {
            QuestionViewModel viewModel = new QuestionViewModel(_quizService.GetQuestionByIdWithAnswersAndExtra(id));
            

            return View(viewModel);
        }


    }
}
