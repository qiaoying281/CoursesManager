using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_PaymentType")]
    public class PaymentType : CommonAbstract
    {
        public PaymentType()
        {
            this.PaymentHistorys = new HashSet<PaymentHistory>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTypeID { get; set; }

        [Required(ErrorMessage = "Payment type name must not null.")]
        public string PaymentTypeName { get; set; }

        public virtual ICollection<PaymentHistory> PaymentHistorys { get; set; }
    }
}