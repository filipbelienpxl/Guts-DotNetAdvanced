using System;
using System.Collections.Generic;
using System.Linq;
using QuizApplication.AppLogic.Contracts;
using QuizApplication.Domain;

namespace QuizApplication.AppLogic
{
    internal class QuizService : IQuizService 
    {
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuizService(ICategoryRepository categoryRepo, IQuestionRepository questionRepo)
        {
            _categoryRepository = categoryRepo;
            _questionRepository = questionRepo;
        }


        public IReadOnlyList<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Question GetQuestionByIdWithAnswersAndExtra(int id)
        {
            return _questionRepository.GetByIdWithAnswers(id);
        }

        public IReadOnlyList<Question> GetQuestionsInCategory(int id)
        {
            return _questionRepository.GetByCategoryId(id);

        }

    }
}
