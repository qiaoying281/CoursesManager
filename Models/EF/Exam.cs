using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Exam")]
    public class Exam : CommonAbstract
    {
        public Exam()
        {
            this.Questions = new HashSet<Question>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamID { get; set; }

        [Required(ErrorMessage = "Course part ID must not null.")]
        public int CoursePartID { get; set; }

        [Required(ErrorMessage = "Exam type ID must not null.")]
        public int ExamTypeID { get; set; }

        [Required(ErrorMessage = "Exam name must not null.")]
        public string ExamName { get; set; }

        [Required(ErrorMessage = "Description must not null.")]
        public string Description { get; set; }
        [AllowHtml]

        [Required(ErrorMessage = "Work time must not null.")]
        public int WorkTime { get; set; }

        [Required(ErrorMessage = "Due date must not null.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Min grade must not null.")]
        public double MinGrade { get; set; }

        public bool IsActive { get; set; }

        public virtual CoursePart CoursePart { get; set; }
        public virtual ExamType ExamType { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}