using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Levi9.Cinema.Api.Controllers
{
    [Route("api/health")]
    [Route("/")]
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        public HttpStatusCode Get()
        {
            return HttpStatusCode.OK;
        }
    }
}
