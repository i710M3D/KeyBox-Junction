namespace KeyBox.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } // The actual question text

        // Foreign key for the Quiz
        public int QuizId { get; set; }
        public Quizz Quiz { get; set; }

        // Navigation properties
        public ICollection<Option> Options { get; set; } // Options for the question
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
