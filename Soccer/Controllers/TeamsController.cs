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
        public ITeamRepository teams { get; set; }

        // Need to define a parameterless constructor for controller
        public TeamsController() { }
        public TeamsController(Stream stream)
        {
            // Inject the stream so we can test this Controller
            inStream = stream;
        }

        // GET /teams
        [HttpGet]
        public ActionResult Index()
        {
            teams = new TeamRepository();
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
                return Json(new { Success = true, Teams = teams, Smallest = new TeamModel("Empty")}, JsonRequestBehavior.AllowGet);
            }
            var smallest = FantasyFootballCheater.CalcSmallestDiff(teams);
            return Json(new { Success = true, Teams = teams.GetAll(), Smallest = smallest }, JsonRequestBehavior.AllowGet);
        }

        // POST /teams
        public ActionResult AddTeams()
        {
            ITeamRepository teams = null;
            if (inStream == null)
            {
                using (var stream = new FileStream(Server.MapPath("~/App_Data") + @"\football.csv", FileMode.Open))
                {
                    teams = FantasyFootballCheater.GetTeams(stream);
                }
            }
            else
            {
                teams = FantasyFootballCheater.GetTeams(inStream);
            }
            if (teams.Count == 0)
            {
                System.Console.WriteLine("No records in Team file");
                return Json(new { Success = true, Teams = teams, Smallest = new TeamModel("Empty") }, JsonRequestBehavior.AllowGet);
            }
            var smallest = FantasyFootballCheater.CalcSmallestDiff(teams);
            return Json(new { Success = true, Teams = teams, Smallest = smallest }, JsonRequestBehavior.AllowGet);
        }

        public class NewTeamVM
        {
            public string Name { get; set; }
            public int For { get; set; }
            public int Against { get; set; }
        }

        // POST /teams
        [HttpPost]
        public ActionResult New(NewTeamVM team)
        {
            if (team == null)
            {
                return Json(new { Success = false });
            }
            var newTeam = new TeamModel(team.Name, 0, 0, 0, 0, team.For, team.Against, 0);
            
            return Json(new { Success = true, team = team });
        }
    }
}
