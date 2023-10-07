using System.ComponentModel.DataAnnotations;

namespace KeyBox.Core.Models
{
    public class Teacher
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
        public string Sex { get; set; }
        public bool IsArchive { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
