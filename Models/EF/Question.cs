using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Question")]
    public class Question : CommonAbstract
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }

        [Required(ErrorMessage = "Exam ID must not null.")]
        public int ExamID { get; set; }

        [Required(ErrorMessage = "Question name must not null.")]
        public string QuestionName { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Exam Exam { get; set; }
    }
}