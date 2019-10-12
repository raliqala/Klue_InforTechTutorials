using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("TutorToProgramming")]
    public class TutorToProgramming
    {
        [Key]
        public int TutorToProgrammingId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Programming")]
        public int ProgrammingId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Programming Programming { get; set; }
    }
}