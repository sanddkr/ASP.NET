using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportService.Models
{
    public class TeamDTO
    {
        public string type_of_sport { get; set; }
        public string coach_name { get; set; }
        public string season { get; set; }
        public decimal fee { get; set; }
    }
}