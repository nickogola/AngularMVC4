using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soccer.Services;
using System.IO;
using Soccer.Models;

namespace Soccer.Test
{
    [TestClass]
    public class FantasyFootballCheaterTest
    {

        // Helper to creeate a stream from a string
        public Stream CreateStream(string content)
        {
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
        }

        [TestMethod]
        public void TestGetEmptyTeams()
        {
            var stream = CreateStream("");
            var teams = FantasyFootballCheater.GetTeams(stream);
            Assert.AreEqual(0, teams.Count);

            stream = CreateStream("Team,P,W,L,D,F,-,A,Pts");
            teams = FantasyFootballCheater.GetTeams(stream);
            Assert.AreEqual(0, teams.Count);
        }

        [TestMethod]
        public void TestGetTeam()
        {
            string content = "Team,P,W,L,D,F,-,A,Pts\nArsenal,38,26,9,3,79,-,36,87";
            var stream = CreateStream(content);
            var teams = FantasyFootballCheater.GetTeams(stream);
            Assert.AreEqual(1, teams.Count);
            var arsenal = (TeamModel)teams[0];
            Assert.AreEqual("Arsenal", arsenal.Name);
            Assert.AreEqual(36, arsenal.Against);
            Assert.AreEqual(43, arsenal.Diff);
            Assert.AreEqual(3, arsenal.Draw);
            Assert.AreEqual(79, arsenal.Goals);
            Assert.AreEqual(9, arsenal.Lost);
            Assert.AreEqual(38, arsenal.Played);
            Assert.AreEqual(87, arsenal.Points);
            Assert.AreEqual(26, arsenal.Won);
        }

        [TestMethod]
        public void TestGetTeams()
        {
            string content = @"Team,P,W,L,D,F,-,A,Pts
                Arsenal,38,26,9,3,79,-,36,87
                Liverpool,38,24,8,6,67,-,30,80";
            var stream = CreateStream(content);
            var teams = FantasyFootballCheater.GetTeams(stream);
            Assert.AreEqual(2, teams.Count);
            var arsenal = (TeamModel)teams[0];
            Assert.AreEqual("Arsenal", arsenal.Name.Trim());
            var liverpool = (TeamModel)teams[1];
            Assert.AreEqual(80, liverpool.Points);
        }

        [TestMethod]
        public void TestCalcSmallestDiff()
        {
            string content = @"Team,P,W,L,D,F,-,A,Pts
                Arsenal,38,26,9,3,79,-,36,87
                Liverpool,38,24,8,6,67,-,30,80";
            var stream = CreateStream(content);
            var teams = FantasyFootballCheater.GetTeams(stream);
            var smallest = FantasyFootballCheater.CalcSmallestDiff(teams);
            Assert.AreEqual(1, smallest.Count);
            Assert.AreEqual("Liverpool", smallest[0].Name.Trim());
            
            // Check that we've updated the flag when we passed it as a parameter
            Assert.IsFalse(teams[0].SmallestDiff);
            Assert.IsTrue(teams[1].SmallestDiff);
        }
    }
}
