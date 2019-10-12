using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("FileDetails")]
    public class FileDetail
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

        public DateTime  Date { get; set; }

        [ForeignKey("Tutorial")]
        public int TutorialId { get; set; }
        public virtual Tutorial Tutorial { get; set; }
    }
}