using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_CoursePart")]
    public class CoursePart : CommonAbstract
    {
        public CoursePart()
        {
            this.Exams = new HashSet<Exam>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoursePartID { get; set; }

        [Required(ErrorMessage = "Course ID must not null.")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Part title must not null.")]
        public string PartTitle { get; set; }

        [Required(ErrorMessage = "Amount must not null.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Duration must not null.")]
        public int Duration { get; set; }

        public bool IsWatched { get; set; }

        public bool IsWatching { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Index must not null.")]
        public int Index { get; set; }

        public virtual Course Courses { get; set; }
        
        public virtual ICollection<Exam> Exams { get; set; }
    }
}