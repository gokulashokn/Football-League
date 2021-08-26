using Football_League.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Football_League.Models
{
    public class MatchManager : IMatchManager
    {
        private readonly AppDbContext _appDbContext;

        public MatchManager(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public String createMatch(string home, string away, string matchResult, string winner)
        {
            try
            {
                PlayedMatch match = new PlayedMatch
                {
                    matchId = Guid.NewGuid().ToString(),
                    home = home,
                    away = away,
                    matchResult = matchResult,
                    winner = winner
                };

                var result = _appDbContext.fbl_playedmatch.Add(match);
                _appDbContext.SaveChanges();
                return result.Entity.matchId;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public string deleteMatch(String id)
        {
            try
            {
                var result = _appDbContext.fbl_playedmatch.FirstOrDefault(p => p.matchId.Equals(id));
                if (result != null)
                {
                    _appDbContext.fbl_playedmatch.Remove(result);
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

        public PlayedMatch getMatch(String id)
        {
            return _appDbContext.fbl_playedmatch.FirstOrDefault(e => e.matchId.Equals(id));
        }

        public List<TeamStandings> getStandings() {
            try
            {
                List<PlayedMatch> allMatches = getAllMatches();
                TeamManager tm = new TeamManager(_appDbContext);
                List<Team> allTeam = tm.getAllTeams();
                List<TeamStandings> standings = new List<TeamStandings>();

                foreach (Team t in allTeam)
                {
                    int total_played = 0;
                    List<PlayedMatch> pm_list1 = allMatches.FindAll(pm => pm.home == t.Name);
                    List<PlayedMatch> pm_list2 = allMatches.FindAll(pm => pm.away == t.Name);

                    total_played = pm_list1.Count() + pm_list2.Count();

                    List<PlayedMatch> win_list = allMatches.FindAll(pm => pm.winner == t.Name);

                    int wins = win_list.Count();

                    List<PlayedMatch> draw_list = allMatches.FindAll(pm => (pm.home == t.Name || pm.away == t.Name) && pm.matchResult == "draw");

                    int draws = draw_list.Count();

                    int total_points = (wins * 3) + draws;

                    int loss = total_played - wins - draws;

                    //Models -Standings (name. total_played, wins, loss, draws, total_points)
                    standings.Add(new TeamStandings
                    {
                        name = t.Name,
                        total_played = total_played,
                        wins = wins,
                        loss = loss,
                        draws = draws,
                        total_points = total_points
                    });
                    standings.Sort((x,y)=>x.total_points.CompareTo(y.total_points));   
                    //new Standings() -- add to list
                }

                return standings.OrderByDescending(o=>o.total_points).ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<PlayedMatch> getAllMatches()
        {
            return _appDbContext.Set<PlayedMatch>().ToList();
        }

        public String updateMatchResult(String id, string matchResult, string winner)
        {
            try
            {
                var result = _appDbContext.fbl_playedmatch.FirstOrDefault(e => e.matchId.Equals(id));

                if (result != null)
                {
                    result.matchResult = matchResult;
                    result.winner = winner;
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
