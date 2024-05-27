using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_CourseType")]
    public class CourseType : CommonAbstract
    {
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseTypeID { get; set; }

        [Required(ErrorMessage = "Course name must not null.")]
        public string CourseTypeName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}