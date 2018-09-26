using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public static class OpenWeatherHelper
    {
        private static string baseUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        private static string key = "deb6fe2b11af239f19af35b7a3dec0b7";

        public static WeatherModel getForecastFor(string city,string country)
        {
            return JsonConvert.DeserializeObject<WeatherModel>(RequestHelper.request(string.Format(baseUrl,city+","+country,key),false));
        }
    }
}
