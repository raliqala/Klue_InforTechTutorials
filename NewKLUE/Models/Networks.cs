using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("NetWorks")]
    public class Networks
    {
        [Key]
        public int NetWorksId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ApplicationUser> User { get; set; }
    }

}