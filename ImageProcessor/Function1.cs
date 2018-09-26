using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ImageProcessor
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("imageQueue", Connection = "")]string myQueueItem, ILogger log)
        {
            //get image from azure maps
           

        }
    }
}
