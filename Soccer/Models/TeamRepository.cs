using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soccer.Models
{
    public class TeamRepository : ITeamRepository
    {
        public IList<Team> teams;

        public TeamRepository()
        {
            teams = new List<Team>();
        }

        public void Add(string name, int played, int won, int lost, int draw, int goals, int against, int points)
        {
            teams.Add(new Team(name, played, won, lost, draw, goals, against, points));
        }

        public int Count { get { return teams.Count; } }
        public void Add(string row) { teams.Add(new Team(row)); }
        public void Add(Team team) { teams.Add(team); }
        public IEnumerable<Team> GetAll() { return teams; }
        public IEnumerator<Team> GetEnumerator() { return teams.GetEnumerator(); }
    }
}