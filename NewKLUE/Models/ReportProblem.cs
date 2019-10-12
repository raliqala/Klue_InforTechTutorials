using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("Report")]
    public class ReportProblem
    {
        [Key]
        public Int32 Id { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email field is requied")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject fiel is required")]
        [Display(Name = "Subject")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message field is requied")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Email me")]
        public bool IsChecked { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}