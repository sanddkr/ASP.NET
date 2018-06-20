using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportService.Models
{
    public class Team
    {
        [Key]
        public string type_of_sport { get; set; }
        [Required]
        public string coach_name { get; set; }
        public string season { get; set; }
        public decimal fee { get; set; }

        //public ICollection<Athlete> Athletes { get; set; }
    }
}