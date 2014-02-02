using Soccer.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Soccer.Services
{
    public class FantasyFootballCheater
    {
        public static IList<Team> GetTeams(Stream file)
        {
            var fileHandler = new FileHandler(file);
            var content = fileHandler.ParseContent();
            var teams = new List<Team>();

            foreach (var line in content)
            {
                var team = new Team(line);
                // If it is a valid team, add it to the list
                if (team != null && team.Name != null && team.Name.Length >= 0)
                {
                    teams.Add(team);
                }
            }
            return teams;
        }

        public static IList<Team> CalcSmallestDiff(IList<Team> teams)
        {       
            // use LinQ to find the minimum difference
            var smallest = teams.Min(team => team.Diff);
            // Need to cater for multiple teams having the minimum diff
            var smallestTeams = new List<Team>();
            foreach (var team in teams)
            {
                if (team.Diff == smallest)
                {
                    smallestTeams.Add(team);
                    team.SmallestDiff = true;
                }
            }
            return smallestTeams;
        }
    }
}