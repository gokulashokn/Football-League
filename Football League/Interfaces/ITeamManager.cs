using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models;

namespace Football_League.Interfaces
{
   public interface ITeamManager
    {
        public String createTeam(String teamname, String managername);

        public Team getTeam(String id);

        public List<Team> getAllTeams();

        public String updateTeamManager(String id, String mgrName);

        public string deleteTeam(String id);


    }
}
