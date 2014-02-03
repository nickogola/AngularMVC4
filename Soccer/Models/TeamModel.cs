using System;
using System.Web.Mvc;

namespace Soccer.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
        public int Goals { get; set; }
        public int Against { get; set; }
        public int Points { get; set; }
        public int Diff { get { return Math.Abs(Goals - Against); } }
        public bool SmallestDiff { get; set; }

        public TeamModel(string name, int played, int won, int lost, int draw, int goals, int against, int points)
        {
            Name = name;
            Played = played;
            Won = won;
            Lost = lost;
            Draw = draw;
            Goals = goals;
            Against = against;
            Points = points;
        }

        public TeamModel(string row)
        {
            var values = row.Split(',');
            if (values.Length != 9) {
                return;
            }
            if (values[0].ToString().Trim().Length == 0) {
                return;
            }
            Name = values[0];
            Played = int.Parse(values[1]);
            Won = int.Parse(values[2]);
            Lost = int.Parse(values[3]);
            Draw = int.Parse(values[4]);
            Goals = int.Parse(values[5]);
            Against = int.Parse(values[7]);
            Points = int.Parse(values[8]);
        }

        public override string ToString()
        {
            return string.Format("Team: {0}\tFor: {1}\tAgainst: {2}. Diff = {3}");
        }
    }
}