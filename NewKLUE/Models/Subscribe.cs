using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("Email")]
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        [Display(Name = "Subscribe")]
        public string Email { get; set; }
    }
}