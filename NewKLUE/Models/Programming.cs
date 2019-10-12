using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("Programming")]
    public class Programming
    {
        [Key]
        public int ProgrammingId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TutorToProgramming> TutorToProgramminger { get; set; }

    }

}