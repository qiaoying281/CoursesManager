using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_PaymentHistory")]
    public class PaymentHistory : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentHistoryID { get; set; }

        [Required(ErrorMessage = "Student ID must not null.")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Payment type ID must not null.")]
        public int PaymentTypeID { get; set; }

        [Required(ErrorMessage = "Payment name must not null.")]
        public string PaymentName { get; set; }

        [Required(ErrorMessage = "Amount must not null.")]
        public int Amount { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual Student Student { get; set; }
    }
}