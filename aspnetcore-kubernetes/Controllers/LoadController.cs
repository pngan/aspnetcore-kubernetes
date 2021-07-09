using aspnetcore_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace aspnetcore_kubernetes.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class LoadController : Controller
    {
        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet]
        [Route("info")]
        public IActionResult Info()
        {
            var model = new HomePageViewModel();
            return Ok(JsonSerializer.Serialize(model));
        }
    }
}
