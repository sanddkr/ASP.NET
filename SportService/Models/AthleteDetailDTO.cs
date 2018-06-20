using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportService.Models
{
    public class AthleteDetailDTO
    {
        public string student_number { get; set; }
   
        public string student_name { get; set; }

        public string type_of_sport { get; set; } // // Foreign Key
        public DateTime birthday { get; set; }
        public Decimal height { get; set; }
    }
}