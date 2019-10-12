using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    public class UsersViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string UserBio { get; set; }
        public string WebUrl { get; set; }
        public string CompanyName { get; set; }

        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Dribble { get; set; }
        public string GitHub { get; set; }
        public string Twitter { get; set; }

        public List<CheckBoxViewModel> Programming { get; set; }
    }
}