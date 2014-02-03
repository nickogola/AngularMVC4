using Soccer.Models;
using System.Web.Mvc;
using System.Web.Helpers;

namespace Soccer.Controllers
{
    public class TeamController : Controller
    {


        // POST /team
        [HttpPost]
        public ActionResult PostTeam(TeamModel team)
        {
            //var team = new TeamModel(data.Name, 0, 0, 0, 0, data.Goals, data.Against, 0);
            if (team == null)
            {
                return Json(new { Success = false });
            }
            // TODO! Save the new team to a DB once we have one
            return Json(new { Success = true, team = team });
        }

        //[HttpPost]
        //public HttpResponseMessage PostObj(Test test)
        //{
        //    //var team = new TeamModel(data.Name, 0, 0, 0, 0, data.Goals, data.Against, 0);
        //    if (test == null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        //    }
        //    var response = Request.CreateResponse(HttpStatusCode.Created, test);
        //    // TODO! Save the new team to a DB once we have one
        //    return response;
        //}

    }
}
