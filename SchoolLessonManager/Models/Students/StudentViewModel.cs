using System.ComponentModel.DataAnnotations;

namespace SchoolLessonManager.Presentation.Models.Students
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Şagird nömrəsi boş ola bilməz.")]
        [Range(1, 99999, ErrorMessage = "Şagird nömrəsi 5 rəqəmli olmalıdır.")]
        public int? Number { get; set; }

        [Required(ErrorMessage = "Adı daxil edin.")]
        [StringLength(30, ErrorMessage = "Ad maksimum 30 simvol ola bilər.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyadı daxil edin.")]
        [StringLength(30, ErrorMessage = "Soyad maksimum 30 simvol ola bilər.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sinif daxil edilməlidir.")]
        [Range(1, 11, ErrorMessage = "Sinif 1 ilə 11 arasında olmalıdır.")]
        public int? GradeLevel { get; set; }
    }
}
