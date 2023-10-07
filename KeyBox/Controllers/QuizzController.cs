using KeyBox.Core.Dto.Quizz;
using KeyBox.Core.Interfaces.IRepos;
using KeyBox.Core.Models;
using KeyBox.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        private readonly QuizzServices _quizzService;

        public QuizzController(QuizzServices quizzService)
        {
            _quizzService = quizzService;
        }

        // POST: api/quizz
        [HttpPost]
        public IActionResult CreateQuiz([FromBody] QuizzInput quizz)
        {
            var result = _quizzService.CreateQuiz(quizz);
            return CreatedAtAction(nameof(GetQuiz), new { id = result.Id }, result);
        }

        // GET: api/quizz/{id}
        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            var quiz = _quizzService.GetQuiz(id);
            if (quiz == null)
                return NotFound("Quiz not found.");

            return Ok(quiz);
        }

        // GET: api/quizz
        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizzService.GetAllQuizzes();
            return Ok(quizzes);
        }

        // PUT: api/quizz/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateQuiz(int id, [FromBody] QuizzUpdateDTO quizz)
        {
            try
            {
                var result = _quizzService.UpdateQuiz(quizz);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/quizz/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            try
            {
                _quizzService.DeleteQuiz(id);
                return Ok("Quiz deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
