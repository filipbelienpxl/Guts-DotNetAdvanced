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
            Question questionsWithAnswers = _questionRepository.GetByIdWithAnswers(id);

            bool hasCorrectAnswer = questionsWithAnswers.Answers.Any(a => a.IsCorrect);
            Answer answers = new Answer
            {
                AnswerText = "None of the answers is correct.",
                IsCorrect = !hasCorrectAnswer,
            };

            questionsWithAnswers.Answers.Add(answers);
            return questionsWithAnswers;
        }

        public IReadOnlyList<Question> GetQuestionsInCategory(int id)
        {
            return _questionRepository.GetByCategoryId(id);

        }

    }
}
