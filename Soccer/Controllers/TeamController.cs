using Soccer.Models;
using System.Web.Http;
using System.Net;   
using System.Net.Http;

namespace Soccer.Controllers
{
    public class TeamController : ApiController
    {
        // POST /team
        [HttpPost]
        public HttpResponseMessage PostTeam(TeamModel team)
        {
            //var team = new TeamModel(data.Name, 0, 0, 0, 0, data.Goals, data.Against, 0);
            if (team == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            var response = Request.CreateResponse(HttpStatusCode.Created, team);
            // TODO! Save the new team to a DB once we have one
            return response;
        }
    }
}
