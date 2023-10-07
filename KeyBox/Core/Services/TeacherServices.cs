using KeyBox.Core.Data;
using KeyBox.Core.Dto.Teacher;
using KeyBox.Core.Interfaces.IRepos;
using KeyBox.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace KeyBox.Core.Services
{
    public class TeacherServices : ITeacher
    {
        private readonly AppDbContext _appDbContext;
        public TeacherServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Create a new teacher:
        public TeacherOutputDTO CreateTeacher(TeacherInputDTO input)
        {
            var existingTeacher = _appDbContext.Teachers.FirstOrDefault(t => t.Email == input.Email);
            if (existingTeacher != null)
                throw new Exception("Teacher with this email already exists.");

     


            var teacher = new Teacher
            {
                Nom = input.Nom,
                Prenom = input.Prenom,
                Email = input.Email,
                Sex = input.Sex,
                Username = $"{input.Nom}{input.Prenom}",
                password = Guid.NewGuid().ToString().Substring(0, 8),
                IsArchive = false
            };

            _appDbContext.Teachers.Add(teacher);
            _appDbContext.SaveChanges();

            return new TeacherOutputDTO
            {
                Id = teacher.Id,
                Nom = teacher.Nom,
                Prenom = teacher.Prenom,
                Email = teacher.Email,
                Sex = teacher.Sex,
                IsArchive = teacher.IsArchive
            };
        }

        // Get a specific teacher by email:
        public TeacherOutputDTO GetTeacher(string email)
        {
            var teacher = _appDbContext.Teachers.FirstOrDefault(t => t.Email == email);
            if (teacher == null)
                return null;

            return new TeacherOutputDTO
            {
                Id = teacher.Id,
                Nom = teacher.Nom,
                Prenom = teacher.Prenom,
                Email = teacher.Email,
                Sex = teacher.Sex,
                IsArchive = teacher.IsArchive
            };
        }

        // Get all teachers:
        public IQueryable<TeacherOutputDTO> GetAllTeachers()
        {
            return _appDbContext.Teachers.Select(t => new TeacherOutputDTO
            {
                Id = t.Id,
                Nom = t.Nom,
                Prenom = t.Prenom,
                Email = t.Email,
                Sex = t.Sex,
                IsArchive = t.IsArchive
            });
        }

        // Update a teacher:
        public TeacherOutputDTO UpdateTeacher(int id, TeacherUpdateDTO update)
        {
            var teacher = _appDbContext.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                throw new Exception("Teacher not found.");

            if(update.Nom is not null) teacher.Nom = update.Nom;
            if (update.Prenom is not null) teacher.Prenom = update.Prenom;
            if (update.Email is not null)
                teacher.Email = update.Email;
            if (update.Sex is not null)
                teacher.Sex = update.Sex;
             teacher.Username = $"{update.Nom}{update.Prenom}";

            _appDbContext.Teachers.Update(teacher);
            _appDbContext.SaveChanges();

            return new TeacherOutputDTO
            {
                Id = teacher.Id,
                Nom = teacher.Nom,
                Prenom = teacher.Prenom,
                Email = teacher.Email,
                Sex = teacher.Sex,
                IsArchive = teacher.IsArchive
            };
        }

        // Archive a teacher:
        public Teacher ArchiveTeacher(int id)
        {
            var teacher = _appDbContext.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                throw new Exception("Teacher not found.");

            teacher.IsArchive = true;

            _appDbContext.Teachers.Update(teacher);
            _appDbContext.SaveChanges();
            return teacher;
        }


    }
}
