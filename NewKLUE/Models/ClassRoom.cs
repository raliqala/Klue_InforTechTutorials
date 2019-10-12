using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewKLUE.Models
{
    [Table("ClassRoooms")]
    public class ClassRoom
    {
        [Key]
        public int RoomId { get; set; }
        

        [StringLength(200)]
        public string ClassDesc { get; set; }
        
        public string facebook { get; set; }
        public string Dribbble { get; set; }
        public string YouTube { get; set; }
        public string GitHub { get; set; }
        public string Udemy { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        
    }
}