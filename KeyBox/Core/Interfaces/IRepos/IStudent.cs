using KeyBox.Core.Dto.Student;
using KeyBox.Core.Models;

namespace KeyBox.Core.Interfaces.IRepos
{
    public interface IStudent
    {
        Student CreateStudent(StudentDTO studentDTO);
        Student GetStudentByEmail(string email);
        Student UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO);
        IEnumerable<Student> GetAllStudents();
        Student ArchiveStudent(int id);
    }
}
