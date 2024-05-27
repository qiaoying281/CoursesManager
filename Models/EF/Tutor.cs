using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Tutors")]
    public class Tutor : CommonAbstract
    {
        public Tutor()
        {
            this.Courses = new HashSet<Course>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TutorID { get; set; }

        [Required(ErrorMessage = "Account ID must not null.")]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Full name must not null.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Contact number must not null.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Emai; must not null.")]
        public string Email { get; set; }

        public virtual Account Accounts { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}