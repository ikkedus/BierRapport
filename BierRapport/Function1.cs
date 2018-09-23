
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using System;
using Microsoft.WindowsAzure.Storage.Queue;
using Shared.Helpers;
using Shared.Models;

namespace BierRapport
{

    public static class RequestBierRapport
    {
        [FunctionName("RequestBierRapport")]
        public static async System.Threading.Tasks.Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("Bier rapport aan gevraagd.");
            string city = req.Query["city"];
            string country = req.Query["country"];

            log.LogInformation("Bier rapport aan gevraagd. voor stad:" + city + " in " + country);

            Queue.addToQueue(new LocationQueueItem() { city= city,country = country});

            return city != null
                ? (ActionResult)new OkObjectResult("Message added to queue")
                : new BadRequestObjectResult("please give city and country");
        }
    }
}
