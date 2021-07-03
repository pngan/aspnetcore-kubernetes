using aspnetcore_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace aspnetcore_kubernetes.Controllers
{
    [ApiController]
    [Route("/")]
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
        public string Info()
        {
            var model = new HomePageViewModel();
            return JsonSerializer.Serialize(model);
        }
    }
}
