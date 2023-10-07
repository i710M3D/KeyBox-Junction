using KeyBox.Core.Dto.Teacher;
using KeyBox.Core.Models;

namespace KeyBox.Core.Interfaces.IRepos
{
    public interface ITeacher
    {
        TeacherOutputDTO CreateTeacher(TeacherInputDTO input);
        TeacherOutputDTO GetTeacher(string email);
        IQueryable<TeacherOutputDTO> GetAllTeachers();
        TeacherOutputDTO UpdateTeacher(int id, TeacherUpdateDTO update);
        Teacher ArchiveTeacher(int id);
    }
}
