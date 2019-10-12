using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewKLUE.Models
{
    [Table("Tutorial")]
    public class Tutorial
    {
        [Key]
        public int TutorialId { get; set; }
        
        [Required(ErrorMessage = "Course Name is required")]
        [Display(Name = "Course Name")]
        public string CoursesName { get; set; }

       
        [Display(Name = "Topic")]
        public string Topic { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Tutorial discription is required")]
        [MaxLength(1000, ErrorMessage = "Maximum {1} characters.")]
        public string Description { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(50)]
        public string Votes { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<FileDetail> FileDetail { get; set; }
    }
}