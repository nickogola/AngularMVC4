using Soccer.Models;
using Soccer.Services;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Soccer.Controllers
{
    public class TeamsController : Controller
    {
        public Stream inStream { get; set; }

        // Need to define a parameterless constructor for controller
        public TeamsController() { }
        public TeamsController(Stream stream)
        {
            // Inject the stream so we can test this Controller
            inStream = stream;
        }

        // GET /teams
        public ActionResult Index()
        {
            IList<Team> teams = null;
            if (inStream == null)
            {
                using (var stream = new FileStream(Server.MapPath("~/App_Data") + @"\football.csv", FileMode.Open))
                {
                    teams = FantasyFootballCheater.GetTeams(stream);
                }
            } else
            {
                teams = FantasyFootballCheater.GetTeams(inStream);
            }
            if (teams.Count == 0)
            {
                System.Console.WriteLine("No records in Team file");
                return Json(new { Success = true, Teams = teams, Smallest = new Team("Empty")}, JsonRequestBehavior.AllowGet);
            }
            var smallest = FantasyFootballCheater.CalcSmallestDiff(teams);
            return Json(new { Success = true, Teams = teams, Smallest = smallest }, JsonRequestBehavior.AllowGet);
        }
    }
}
