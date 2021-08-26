using Football_League.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Models
{
    public class TeamStandings
    {
        public String name { get; set; }

        public int total_played { get; set; }

        public int wins { get; set; }

        public int loss { get; set; }

        public int draws { get; set; }

        public int total_points { get; set; }
    }
}
