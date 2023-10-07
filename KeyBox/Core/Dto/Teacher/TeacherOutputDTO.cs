namespace KeyBox.Core.Dto.Teacher
{
    public class TeacherOutputDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public bool IsArchive { get; set; }
    }
}
