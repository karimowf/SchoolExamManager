namespace SchoolLessonManager.Presentation.Models.Exams
{
    public class ExamFilterViewModel
    {
        public string? Lesson { get; set; }
        public string? Student { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
