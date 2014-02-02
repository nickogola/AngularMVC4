using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soccer.Models
{
    public class TeamRepository : ITeamRepository
    {
        public IList<TeamModel> teams;

        public TeamRepository()
        {
            teams = new List<TeamModel>();
        }

        public void Add(string name, int played, int won, int lost, int draw, int goals, int against, int points)
        {
            teams.Add(new TeamModel(name, played, won, lost, draw, goals, against, points));
        }

        public int Count { get { return teams.Count; } }
        public void Add(string row) { teams.Add(new TeamModel(row)); }
        public void Add(TeamModel team) { teams.Add(team); }
        public IEnumerable<TeamModel> GetAll() { return teams; }
        public IEnumerator<TeamModel> GetEnumerator() { return teams.GetEnumerator(); }
    }
}