using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.Models
{
    public interface ITeamRepository
    {
        void Add(string name, int played, int won, int lost, int draw, int goals, int against, int points);
        void Add(string row);
        void Add(Team team);
        IEnumerable<Team> GetAll();
        IEnumerator<Team> GetEnumerator();
        int Count { get; }
    }
}
