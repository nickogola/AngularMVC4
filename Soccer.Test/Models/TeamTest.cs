using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soccer.Models;

namespace Soccer.Test
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void CreateTeam()
        {
            var team = new TeamModel("Name", 1, 2, 3, 4, 6, 5, 7);
            Assert.AreEqual("Name", team.Name);
            Assert.AreEqual(1, team.Played);
            Assert.AreEqual(2, team.Won);
            Assert.AreEqual(3, team.Lost);
            Assert.AreEqual(4, team.Draw);
            Assert.AreEqual(6, team.Goals);
            Assert.AreEqual(5, team.Against);
            Assert.AreEqual(7, team.Points);
            // Extra values
            Assert.AreEqual(1, team.Diff);
            Assert.AreEqual(false, team.SmallestDiff);

            Assert.AreEqual("Team: Name\tFor: 6\tAgainst: 5. Diff = 1", team.ToString());
        }

        [TestMethod]
        public void CreateTeamFromString()
        {
            var team = new TeamModel("Name, 1, 2, 3, 4, 5, -, 6, 7");
            Assert.AreEqual("Name", team.Name);
            Assert.AreEqual(1, team.Played);
            Assert.AreEqual(2, team.Won);
            Assert.AreEqual(3, team.Lost);
            Assert.AreEqual(4, team.Draw);
            Assert.AreEqual(5, team.Goals);
            Assert.AreEqual(6, team.Against);
            Assert.AreEqual(7, team.Points);
            // Extra values
            Assert.AreEqual(1, team.Diff);
            Assert.AreEqual(false, team.SmallestDiff);
        }

        [TestMethod]
        public void CreateTeamFromStringErrors()
        {
            // Not enough fields
            var team = new TeamModel("Arsenal, 1");
            Assert.AreEqual(null, team.Name);

            // Passing a non-int value
            try
            {
                new TeamModel("Name, notnumber, 2, 3, 4, 5, -, 6, 7");
            } catch( Exception ex)
            {
                Assert.AreEqual("Input string was not in a correct format.", ex.Message);
            }
        }
    }
}
