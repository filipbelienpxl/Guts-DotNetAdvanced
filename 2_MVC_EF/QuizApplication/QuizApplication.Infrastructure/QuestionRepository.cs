using QuizApplication.AppLogic.Contracts;
using QuizApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Infrastructure
{
    internal class QuestionRepository : IQuestionRepository
    {
        List<Question> questions;

        public QuestionRepository(QuizDbContext dbContext)
        {
            questions = dbContext.Questions.ToList();
        }

        public IReadOnlyList<Question> GetByCategoryId(int categoryId)
        {
            List<Question> receivedQuestions = questions.Where(q => q.CategoryId == categoryId).ToList();
            return receivedQuestions;
        }

        public Question GetByIdWithAnswers(int id)
        {
            Random random = new Random();
            List<Question> questionsFromIds = questions.Where(q => q.Id == id).ToList();
            questionsFromIds.Add(questions[random.Next(questions.Count())]);
            return questionsFromIds.First();
        }
    }
}
