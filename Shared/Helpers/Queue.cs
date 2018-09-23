using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using System;
using Microsoft.WindowsAzure.Storage.Queue;
using Shared.Models;
using Newtonsoft.Json;

namespace Shared.Helpers
{
    public static class Queue
    {
        public async static void addToQueue(object item,string queueId = "requestbierrapport")
        {
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=bierrapport;AccountKey=dUPhg9OpeA1vNyohiJFDi02RVTEKY5PXODxHwCZFfy2XKQ0okKNuGbVO57Vwe31CRg4BrvtoIQ+gPYZ8p8Xu2A==;EndpointSuffix=core.windows.net");

            var client = storageAccount.CreateCloudQueueClient();

            var queue = client.GetQueueReference(queueId);

            await queue.CreateIfNotExistsAsync();

            await queue.AddMessageAsync(new CloudQueueMessage(JsonConvert.SerializeObject(item)));
        }
    }
}
