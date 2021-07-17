using aspnetcore_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading;

namespace aspnetcore_kubernetes.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class LoadController : Controller
    {
        [HttpGet]
        [Route("runload")]
        public IActionResult RunLoad()
        {
            Thread.SpinWait(200000000);
            return RedirectToAction("Index", "Home");
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
