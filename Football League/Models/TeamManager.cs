using Football_League.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Models
{
    public class TeamManager : ITeamManager
    {
        private readonly AppDbContext _appDbContext;

        public TeamManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public String createTeam(String teamname, String managername)
        {
            try
            {
                Team team = new Team
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = teamname,
                    Manager = managername
                };

                var result = _appDbContext.fbl_team.Add(team);
                _appDbContext.SaveChanges();
                return result.Entity.Id;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new NullReferenceException();
            }
        }

        public List<Team> getAllTeams()
        {
            return _appDbContext.Set<Team>().ToList();
        }

        public string deleteTeam(String id)
        {
            try
            {
                var result = _appDbContext.fbl_team.FirstOrDefault(e => e.Id.Equals(id));
                if (result != null)
                {
                    _appDbContext.fbl_team.Remove(result);
                    _appDbContext.SaveChanges();
                    return "Deleted";
                }
                return null;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Team getTeam(String id)
        {
            try
            {
                return _appDbContext.fbl_team.FirstOrDefault(e => e.Id.Equals(id));
            }
            catch {
                throw new NotImplementedException();
            }
        }

        public string updateTeamManager(String id, string mgrName)
        {
            try
            {
                var result = _appDbContext.fbl_team.FirstOrDefault(e => e.Id.Equals(id));

                if (result != null)
                {
                    result.Manager = mgrName;

                    _appDbContext.SaveChanges();

                    return "Updated";
                }
                return null;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
