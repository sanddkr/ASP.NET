using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportService.Models
{
    public class Athlete
    {
        [Key]
        public string student_number { get; set; }
        [Required]
        public string student_firstname { get; set; }
        [Required]
        public string student_lastname { get; set; }
        [Required]
        public string type_of_sport { get; set; } // // Foreign Key
        public DateTime birthday { get; set; }
        public Decimal height { get; set; }
        public Team team { get; set; }
        //public virtual Team team { get; set; }
    }
}