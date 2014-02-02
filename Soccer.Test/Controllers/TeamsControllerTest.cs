using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soccer.Controllers;
using System.IO;

namespace Soccer.Test.Controllers
{
    [TestClass]
    public class TeamsControllerTest
    {
        // Helper to creeate a stream from a string
        public Stream CreateStream(string content)
        {
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
        }

        [TestMethod]
        public void TestCreateController()
        {
            var ctrl = new TeamsController();
            Assert.AreNotSame(null, ctrl);
        }

        [TestMethod]
        public void TestIndex()
        {
            var ctrl = new TeamsController(CreateStream(""));
            var res = ctrl.Index();
            var data = ((JsonResult)res).Data.ToString();
            Assert.AreEqual("{ Success = True, Teams = System.Collections.Generic.List`1[Soccer.Models.Team], Smallest = Team: \tFor: 0\tAgainst: 0. Diff = 0 }", data);
            Assert.AreEqual(JsonRequestBehavior.AllowGet, ((JsonResult)res).JsonRequestBehavior);
            
            ctrl = new TeamsController(CreateStream(@"Team,P,W,L,D,F,-,A,Pts
                Arsenal,38,26,9,3,79,-,36,87
                Liverpool,38,24,8,6,67,-,30,80"));
            res = ctrl.Index();
            data = ((JsonResult)res).Data.ToString();
            Assert.AreEqual("{ Success = True, Teams = System.Collections.Generic.List`1[Soccer.Models.Team], Smallest = System.Collections.Generic.List`1[Soccer.Models.Team] }", data);
        }

    }
}
