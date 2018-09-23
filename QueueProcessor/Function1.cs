using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Models;

namespace QueueProcessor
{
    

    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("requestbierrapport", Connection = "")]string myQueueItem, ILogger log)
        {
            var item = JsonConvert.DeserializeObject<LocationQueueItem>(myQueueItem);



        }
    }
}
