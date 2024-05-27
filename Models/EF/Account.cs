using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Account")]
    public class Account : CommonAbstract
    {
        public Account()
        {
            this.Students = new HashSet<Student>();
            this.Tutors = new HashSet<Tutor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Email must not null.")]
        public string Email { get; set; }

        public string Avatar { get; set; }

        [Required(ErrorMessage = "Password must not null.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Status must not null.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Decentralization ID must not null.")]
        public int DecentralizationID { get; set; }

        public string ResetPasswordToken { get; set; }
        public DateTime ResetPasswordTokenExpiry { get; set; }

        public virtual Decentralization Decentralizations { get; set; }
       
        public virtual ICollection<Student> Students { get; set; }
        
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}