using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("VoteLog")]
    public class VoteLog
    {
        [Key]
        public int VoteId { get; set; }

        public Int16 SectionId { get; set; }

        public int VoteForId { get; set; }

        public string UserName { get; set; }

        public Int16 Vote { get; set; }

        public bool Active { get; set; }
    }
}