using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Submission")]
    public class Submission : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmissionID { get; set; }

        [Required(ErrorMessage = "Exam ID must not null.")]
        public int ExamID { get; set; }

        [Required(ErrorMessage = "Student ID must not null.")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Exam time must not null.")]
        public int ExamTimes { get; set; }

        [Required(ErrorMessage = "Grade must not null.")]
        public int Grade { get; set; }

        public virtual Student Student { get; set; }
    }
}