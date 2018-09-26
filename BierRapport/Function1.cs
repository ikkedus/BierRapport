
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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
        private static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=bierrapport;AccountKey=dUPhg9OpeA1vNyohiJFDi02RVTEKY5PXODxHwCZFfy2XKQ0okKNuGbVO57Vwe31CRg4BrvtoIQ+gPYZ8p8Xu2A==;EndpointSuffix=core.windows.net");

        [FunctionName("RequestBierRapport")]
        public static async System.Threading.Tasks.Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            if(req.Method == "GET")
            {
                string Id = req.Query["id"];
                if (!string.IsNullOrEmpty(Id))
                {
                    var client = storageAccount.CreateCloudBlobClient();

                    var container = client.GetContainerReference("somecontainer");
                    var blob = container.GetBlobReference(Id+".png");
                    var memStream = new MemoryStream();

                    await blob.DownloadToStreamAsync(memStream);
                    memStream.Position = 0;
                    return (ActionResult)new FileStreamResult(memStream, "image/png") ;
                }
            }
            log.LogInformation("Bier rapport aan gevraagd.");
            string city = req.Query["city"];
            string country = req.Query["country"];
            Guid id = Guid.NewGuid();
            log.LogInformation("Bier rapport aan gevraagd. voor stad:" + city + " in " + country);

            Queue.addToQueue(new LocationQueueItem() {id=id, city= city,country = country});

            return city != null
                ? (ActionResult)new OkObjectResult(""+ id)
                : new BadRequestObjectResult("please give city and country");
        }
    }
}
