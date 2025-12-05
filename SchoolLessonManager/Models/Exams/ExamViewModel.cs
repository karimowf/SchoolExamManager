using System.ComponentModel.DataAnnotations;

namespace SchoolLessonManager.Presentation.Models.Exams
{
    public class ExamViewModel
    {
        [Required(ErrorMessage = "Dərsin kodu daxil edilməlidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Dərsin kodu 3 simvol olmalıdır.")]
        public string LessonCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şagird nömrəsi daxil edilməlidir.")]
        [Range(1, 99999, ErrorMessage = "Şagird nömrəsi 5 rəqəmli olmalıdır.")]
        public int? StudentNumber { get; set; }

        [Required(ErrorMessage = "İmtahan tarixi daxil edilməlidir.")]
        [DataType(DataType.Date)]
        public DateTime? ExamDate { get; set; }

        [Required(ErrorMessage = "Qiymət daxil edilməlidir.")]
        [Range(0, 9, ErrorMessage = "Qiymət 0 ilə 9 arasında olmalıdır.")]
        public int? Score { get; set; }
    }
}
