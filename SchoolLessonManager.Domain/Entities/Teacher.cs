namespace SchoolLessonManager.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }          
        public string LastName { get; set; }           

        public ICollection<Lesson> Lessons { get; set; }
    }
}
