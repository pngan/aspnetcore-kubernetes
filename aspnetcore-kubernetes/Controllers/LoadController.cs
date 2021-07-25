using aspnetcore_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        public async Task<IActionResult> RunLoad(long n = 1000000)
        {
            await GenerateLoadAsync(n);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("info")]
        public IActionResult Info()
        {
            var model = new HomePageViewModel();
            return Ok(JsonSerializer.Serialize(model));
        }

        private async Task GenerateLoadAsync(long numberIterations)
        {
            Console.WriteLine("Generating Load...");
            var allTasks = new List<Task>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var task = Task.Run(async () => await LoadCpuAsync(numberIterations));
                allTasks.Add(task);
            }

            await Task.WhenAll(allTasks);
        }


        private async Task LoadCpuAsync(long numberIterations)
        {
            while (numberIterations-- > 0)
            {
                await Task.Yield();
            }
        }
    }
}
