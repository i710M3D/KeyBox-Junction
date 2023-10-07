namespace KeyBox.Core.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ICollection<Student> Students { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
