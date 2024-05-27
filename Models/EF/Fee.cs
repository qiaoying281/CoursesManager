using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models.EF
{
    [Table("tb_Fee")]
    public class Fee : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeeID { get; set; }

        [Required(ErrorMessage = "Student ID must not null.")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Course ID must not null.")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Cost must not null.")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Status must not null.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Is Checked must not null.")]
        public bool IsChecked {  get; set; }

        public virtual Student Student { get; set; }
    }
}