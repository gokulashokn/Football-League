using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Models
{
    public class PlayedMatch
    {
        //database fields
        [Key]
        public String matchId { get; set; }
        
        public String home { get; set; }

        public String away { get; set; }

        public String matchResult { get; set; }

        public String winner { get; set; }
    }
}
