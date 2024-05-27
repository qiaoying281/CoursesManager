using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_VerifyCodes")]
    public class VerifyCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VerifyCodeID { get; set; }

        [Required(ErrorMessage = "Email must not null.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Code must not null.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Expired time must not null.")]
        public DateTime ExpiredTime { get; set; }
    }
}