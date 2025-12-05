namespace SchoolLessonManager.Domain.Entities
{
    public class Student : BaseEntity
    {
        public int Number { get; set; }
        public string FirstName { get; set; }          
        public string LastName { get; set; }           
        public int GradeLevel { get; set; }             

        public ICollection<Exam> Exams { get; set; }
    }
}
