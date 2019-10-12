using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("SupportServices")]
    public class SupportServices
    {
        [Key]
        public int SupportId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}