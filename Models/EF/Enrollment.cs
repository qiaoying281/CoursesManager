using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_Enrollment")]
    public class Enrollment : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID {  get; set; }

        [Required(ErrorMessage = "Student ID must not null.")]
        public int StudentID {  get; set; }

        [Required(ErrorMessage = "Course ID must not null.")]
        public int CourseID {  get; set; }

        public virtual Student Student { get; set; }
    }
}