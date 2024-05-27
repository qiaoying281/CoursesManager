using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhoaHocOnline.Models
{
    public abstract class CommonAbstract
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get;set; }
    }
}