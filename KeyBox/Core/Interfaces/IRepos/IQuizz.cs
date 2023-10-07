using KeyBox.Core.Dto.Quizz;
using KeyBox.Core.Models;
using System.Threading.Tasks;

namespace KeyBox.Core.Interfaces.IRepos
{
    public interface IQuizz
    {
        Quizz CreateQuiz(QuizzInput quizz);
        Quizz GetQuiz(int quizId);
        Task<IEnumerable<Quizz>> GetAllQuizzes();
        Quizz UpdateQuiz(QuizzUpdateDTO updatedQuiz);
        void DeleteQuiz(int quizId);
    }
}
