namespace KeyBox.Core.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Text { get; set; } // The option text
        public bool IsCorrect { get; set; } // Indicates if this option is the correct answer

        // Foreign key for the Question
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
