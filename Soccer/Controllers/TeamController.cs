using Soccer.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace Soccer.Controllers
{
    public class TeamController : ApiController
    {
        // POST /team/add
        public HttpResponseMessage AddTeam(Team team)
        {
            System.Console.Write("Hi team", team);
            var response = Request.CreateResponse(HttpStatusCode.Created, team);
            return response;
        }  
    }
}
