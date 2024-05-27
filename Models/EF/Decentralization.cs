using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table ("tb_Decentralization")]
    public class Decentralization : CommonAbstract
    {
        public Decentralization()
        {
            this.Accounts = new HashSet<Account>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DecentralizationID { get; set; }

        [Required(ErrorMessage = "Authority name must not null.")]
        public string AuthorityName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}