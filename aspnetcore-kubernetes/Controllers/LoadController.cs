using aspnetcore_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace aspnetcore_kubernetes.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class LoadController : Controller
    {
        [HttpGet]
        [Route("runload")]
        public async Task<IActionResult> RunLoad()
        {
            await GenerateLoadAsync(10, 30);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("info")]
        public IActionResult Info()
        {
            var model = new HomePageViewModel();
            return Ok(JsonSerializer.Serialize(model));
        }

        private async Task GenerateLoadAsync(int intervalInSeconds, int percentageLoad = 100)
        {
            Console.WriteLine("Generating Load...");
            var allTasks = new List<Task>();
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(intervalInSeconds));
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var task = Task.Run(() => LoadCpuAsync(cts.Token, percentageLoad));
                allTasks.Add(task);
            }

            await Task.WhenAll(allTasks);
        }

        private async Task LoadCpuAsync(CancellationToken ct, int percentageLoad)
        {
            while (!ct.IsCancellationRequested)
            {
                LoadCpu(percentageLoad);
                await Task.Delay(100 - percentageLoad);
            }
        }
        private void LoadCpu(int millisecondsDuration)
        {
            var timer = new Stopwatch();
            timer.Start();
            while (timer.ElapsedMilliseconds < millisecondsDuration) ;
        }
    }
}
