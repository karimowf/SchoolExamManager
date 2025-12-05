namespace SchoolLessonManager.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public string Code { get; set; }                
        public string Name { get; set; }                
        public int GradeLevel { get; set; }            
        public int TeacherId { get; set; }             

        public Teacher Teacher { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
