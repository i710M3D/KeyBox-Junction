namespace KeyBox.Core.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }

        // Foreign keys
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int StudentId { get; set; } // Assuming you have a Student model
        public int OptionId { get; set; } // The option chosen by the student
        public Option Option { get; set; }
    }
}
