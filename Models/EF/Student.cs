using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Student")]
    public class Student : CommonAbstract
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
            this.Fees = new HashSet<Fee>();
            this.PaymentHistorys = new HashSet<PaymentHistory>();
            this.Submissions = new HashSet<Submission>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Account ID must not null.")]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Full name must not null.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Contact number must not null.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email must not null.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Total money must not null.")]
        public int TotalMoney { get; set; }

        public virtual Account Account { get; set; }
       
        public virtual ICollection<Enrollment> Enrollments { get; set; }
       
        public virtual ICollection<Fee> Fees { get; set; }
        
        public virtual ICollection<PaymentHistory> PaymentHistorys { get; set; }
       
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}