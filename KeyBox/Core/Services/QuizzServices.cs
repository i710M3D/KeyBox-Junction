using KeyBox.Core.Data;
using KeyBox.Core.Models;
using KeyBox.Core.Dto.Quizz;
using Microsoft.EntityFrameworkCore;
using KeyBox.Core.Interfaces.IRepos;

namespace KeyBox.Core.Services
{
    public class QuizzServices : IQuizz
    {
        private readonly AppDbContext _appDbContext;
        public QuizzServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Quizz CreateQuiz(QuizzInput q)
        {
            var quizz = new Quizz
            {
                Title = q.Title,
                Description = q.Description,
                Questions = new List<Question>()


            };
            _appDbContext.Quizzs.Add(quizz);
            _appDbContext.SaveChanges();
            return quizz;
        }
        public Quizz GetQuiz(int quizId)
        {
            return _appDbContext.Quizzs.FirstOrDefault(q => q.Id == quizId);
        }
        public async Task<IEnumerable<Quizz>> GetAllQuizzes()
        {
            return await _appDbContext.Quizzs.ToListAsync();
        }
        public Quizz UpdateQuiz(QuizzUpdateDTO updatedQuiz)
        {
            var quiz = _appDbContext.Quizzs.FirstOrDefault(q => q.Id == updatedQuiz.Id);
            if (quiz == null)
                throw new Exception("Quiz not found.");

            if (updatedQuiz.Title is not null) quiz.Title = updatedQuiz.Title;
            if (updatedQuiz.Description is not null) quiz.Description = updatedQuiz.Description;

            _appDbContext.SaveChanges();
            return quiz;
        }
        public void DeleteQuiz(int quizId)
        {
            var quiz = _appDbContext.Quizzs.FirstOrDefault(q => q.Id == quizId);
            if (quiz == null)
                throw new Exception("Quiz not found.");

            _appDbContext.Quizzs.Remove(quiz);
            _appDbContext.SaveChanges();
        }
    }
}
