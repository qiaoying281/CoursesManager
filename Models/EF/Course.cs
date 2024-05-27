using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_Course")]
    public class Course : CommonAbstract
    {
        public Course()
        {
            this.CourseParts = new HashSet<CoursePart>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Course name must not null.")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course description must not null.")]
        public string CourseDescription { get; set; }
        [AllowHtml]

        [Required(ErrorMessage = "Tutor ID must not null.")]
        public int TutorID { get; set; }

        [Required(ErrorMessage = "Course Type ID must not null.")]
        public int CourseTypeID { get; set; }

        [Required(ErrorMessage = "Cost must not null.")]
        public int Cost { get; set; }

        public bool IsActive {  get; set; }

        public virtual ICollection<CoursePart> CourseParts { get; set; }
        public virtual Tutor Tutors { get; set; }
        public virtual CourseType CourseTypes { get; set; }
    }
}