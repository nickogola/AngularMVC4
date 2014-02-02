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

        // POST /team
        [HttpPost]
        public ActionResult AddTeam(TeamModel team)
        {
            //var team = new TeamModel(data.Name, 0, 0, 0, 0, data.Goals, data.Against, 0);
            if (team == null)
            {
                return Json(new { Success = false });
            }
            return Json(new { Success = true, Team = team }, JsonRequestBehavior.AllowGet);
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
    }
}
