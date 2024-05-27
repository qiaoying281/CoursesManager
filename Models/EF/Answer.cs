using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_Answer")]
    public class Answer : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID {  get; set; }

        [Required(ErrorMessage = "Question ID must not null.")]
        public int QuestionID {  get; set; }

        [Required(ErrorMessage = "Right answer must not null.")]
        public bool RightAnswer { get; set; }

        [Required(ErrorMessage = "Content must not null.")]
        public string Content { get; set; }
        [AllowHtml]

        public virtual Question Questions { get; set; }
    }
}