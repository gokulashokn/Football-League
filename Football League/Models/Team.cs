using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Models
{
    public class Team
    {
        //database fields
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Manager { get; set; }
    }
}
