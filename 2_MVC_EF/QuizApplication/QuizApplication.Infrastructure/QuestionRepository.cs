using Microsoft.EntityFrameworkCore;
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
        
        private readonly QuizDbContext _dbContext;

        public QuestionRepository(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyList<Question> GetByCategoryId(int categoryId)
        {
            return _dbContext.Questions
                .Where(q => q.CategoryId == categoryId)
                .ToList();
        }

        public Question GetByIdWithAnswers(int id)
        {
            return _dbContext.Questions
                .Include(q => q.Answers)
                .FirstOrDefault(q => q.Id == id)!;
        }
    }
}
