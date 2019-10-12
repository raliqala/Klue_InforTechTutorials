using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address required.")]
        [RegularExpression(@".*@.*", ErrorMessage = "Must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}