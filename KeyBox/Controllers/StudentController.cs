using KeyBox.Core.Dto.Student;
using KeyBox.Core.Interfaces.IRepos;
using KeyBox.Core.Models;
using KeyBox.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyBox.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentServices;

        public StudentController(IStudent studentServices)
        {
            _studentServices = studentServices;
        }
        // POST: api/students
        [HttpPost]
        public ActionResult<Student> CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                var student = _studentServices.CreateStudent(studentDTO);
                return CreatedAtAction(nameof(GetStudentByEmail), new { email = student.Email }, student);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{email}")]
        public ActionResult<Student> GetStudentByEmail(string email)
        {
            var student = _studentServices.GetStudentByEmail(email);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(students);
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDTO update)
        {
            try
            {
                var student = _studentServices.UpdateStudent(id, update);
                if (student == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/students/archive/{id}
        [HttpPut("archive/{id}")]
        public ActionResult ArchiveStudent(int id)
        {
            var student = _studentServices.ArchiveStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
