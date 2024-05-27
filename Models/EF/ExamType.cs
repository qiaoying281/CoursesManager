using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_ExamType")]
    public class ExamType : CommonAbstract
    {
        public ExamType()
        {
            this.Exams = new HashSet<Exam>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamTypeID { get; set; }

        [Required(ErrorMessage = "Exam type name must not null.")]
        public string ExamTypeName { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}