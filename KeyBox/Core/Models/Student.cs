
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KeyBox.Core.Models
{
    public class Student

    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Email { get; set; }
        public string password { get; set; }
        public string Username { get; set; } 
        public bool IsArchive { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string role { get; set; }
        public bool IsSport { get; set; }
        public int WeeklyStudyHours { get; set; }
        public bool IsTakingNotes { get; set; }
        public bool IsAttending { get; set; }
        public bool IsArrived { get; set; }
        public bool AdditionalWork { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
