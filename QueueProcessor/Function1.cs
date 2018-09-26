using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Models;
using Shared.Helpers;
using System.Text;
using System.IO;

namespace QueueProcessor
{


    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("requestbierrapport", Connection = "")]string myQueueItem, ILogger log)
        {
            var item = JsonConvert.DeserializeObject<LocationQueueItem>(myQueueItem);
            var forecast = OpenWeatherHelper.getForecastFor(item.city, item.country);
            var image = AzureMapsHelper.getImage(new Tuple<double, double>(forecast.coord.lat, forecast.coord.lon));
            string text2 = "Mooi weer voor bier";
            if (forecast.main.temp < 18)
            {
                text2 = "slecht weer voor bier";
            }
            
            var editedImage = ImageHelper.AddTextToImage(image, ("het is "+forecast.main.temp.ToString()+" graden buiten", (10, 20)), (text2, (150, 300)));
            CloudStoarge.upload(item.id+".png",editedImage as MemoryStream);
        }
    }
}
