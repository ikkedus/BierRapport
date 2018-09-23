using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class requestProcessor
    {
        [FunctionName("requestProcessor")]
        public static void Run([QueueTrigger("requestbierrapport", Connection = "DefaultEndpointsProtocol=https;AccountName=bierrapport;AccountKey=dUPhg9OpeA1vNyohiJFDi02RVTEKY5PXODxHwCZFfy2XKQ0okKNuGbVO57Vwe31CRg4BrvtoIQ+gPYZ8p8Xu2A==;EndpointSuffix=core.windows.net")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
