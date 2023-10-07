namespace KeyBox.Core.Models
{
    public class Quizz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
