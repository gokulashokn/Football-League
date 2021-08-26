using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models;

namespace Football_League.Interfaces
{
    public interface IMatchManager
    {
        public String createMatch(String home, String away, String matchResult, String winner);

        public PlayedMatch getMatch(String id);

        public List<PlayedMatch> getAllMatches();

        public List<TeamStandings> getStandings();

        public String updateMatchResult(String id, String matchResult, string winner);

        public string deleteMatch(String id);


    }
}
