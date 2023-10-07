using KeyBox.Core.Dto.Teacher;
using KeyBox.Core.Interfaces.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace KeyBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacherservice)
        {
            _teacherService = teacherservice;
        }
        // POST: api/teacher
        [HttpPost]
        public IActionResult CreateTeacher([FromBody] TeacherInputDTO input)
        {
            try
            {
                var result = _teacherService.CreateTeacher(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/teacher/{email}
        [HttpGet("{email}")]
        public IActionResult GetTeacher(string email)
        {
            var teacher = _teacherService.GetTeacher(email);
            if (teacher == null)
                return NotFound("Teacher not found.");

            return Ok(teacher);
        }

        // GET: api/teacher
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherService.GetAllTeachers();
            return Ok(teachers);
        }

        // PUT: api/teacher/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] TeacherUpdateDTO update)
        {
            try
            {
                var result = _teacherService.UpdateTeacher(id, update);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/teacher/archive/{id}
        [HttpPut("archive/{id}")]
        public IActionResult ArchiveTeacher(int id)
        {
            try
            {
                _teacherService.ArchiveTeacher(id);
                return Ok("Teacher archived successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
