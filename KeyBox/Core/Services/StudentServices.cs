using KeyBox.Core.Data;
using KeyBox.Core.Models;
using KeyBox.Core.Interfaces.IRepos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeyBox.Core.Dto.Student;

namespace KeyBox.Core.Services
{
    public class StudentServices : IStudent
    {
        private readonly AppDbContext _appDbContext;
        public StudentServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Student CreateStudent(StudentDTO studentDTO)
        {
            // Check if the student with the given email already exists
            var existingStudent = _appDbContext.Students.FirstOrDefault(s => s.Email == studentDTO.Email);
            if (existingStudent != null)
            {
                throw new InvalidOperationException("A student with the given email already exists.");
            }

            if (studentDTO.Role != "SENIOR" && studentDTO.Role != "JUNIOR")
            {
                throw new ArgumentException("Role must be SENIOR or JUNIOR");
            }

            // Generate a random password (you can change this logic as needed)
            var password = Guid.NewGuid().ToString().Substring(0, 8);
            // Encryption logic here (you can use any encryption method you prefer)

            var student = new Student
            {
                Nom = studentDTO.Nom,
                Prenom = studentDTO.Prenom,
                Email = studentDTO.Email,
                role = studentDTO.Role,
                password = password,  // Store encrypted password
                Age = 0,
                Sex = "N",
                IsSport = false,
                IsArrived = false,
                IsAttending = false,
                IsTakingNotes = false,
                WeeklyStudyHours = 0,
            };

            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();

            return student;
        }
        public Student GetStudentByEmail(string email)
        {
            return _appDbContext.Students.FirstOrDefault(s => s.Email == email);
        }
        public Student UpdateStudent(int id, StudentUpdateDTO update)
        {
            var student = _appDbContext.Students.Find(id);
           
                if (update.Nom is not null) student.Nom = update.Nom;
                if (update.Prenom is not null) student.Prenom = update.Prenom;
                if (update.Email is not null) student.Email = update.Email;
                if (update.Role is not null) student.role= update.Role;

                _appDbContext.SaveChanges();
            return student;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContext.Students.ToList();
        }
        public Student ArchiveStudent(int id)
        {
            var student = _appDbContext.Students.Find(id);
            if (student != null)
            {
                // Assuming you'll add an IsArchived property to the Student model
                student.IsArchive = true;
                _appDbContext.SaveChanges();
            }
            return student;
        }

    }
}
