using System.ComponentModel.DataAnnotations;

namespace SchoolLessonManager.Presentation.Models.Lessons
{
    public class LessonViewModel
    {
        [Required(ErrorMessage = "Dərs kodu boş ola bilməz.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Dərs kodu mütləq 3 simvoldan ibarət olmalıdır.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Dərsin adı boş ola bilməz.")]
        [StringLength(30, ErrorMessage = "Dərsin adı maksimum 30 simvol ola bilər.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sinif boş ola bilməz.")]
        [Range(1, 11, ErrorMessage = "Sinif 1 ilə 12 arasında olmalıdır.")]
        public int GradeLevel { get; set; }

        [Required(ErrorMessage = "Müəllimin adı boş ola bilməz.")]
        [StringLength(20, ErrorMessage = "Müəllimin adı maksimum 20 simvol ola bilər.")]
        public string TeacherFirstName { get; set; }

        [Required(ErrorMessage = "Müəllimin soyadı boş ola bilməz.")]
        [StringLength(20, ErrorMessage = "Müəllimin soyadı maksimum 20 simvol ola bilər.")]
        public string TeacherLastName { get; set; }
    }
}
