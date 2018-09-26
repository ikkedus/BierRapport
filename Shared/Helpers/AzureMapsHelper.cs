using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shared.Helpers
{


    public class AzureMapsHelper
    {
        private static string baseUrl = "https://atlas.microsoft.com/map/static/png?subscription-key={0}&api-version=1.0&center={1}";
        private static string key = "idv0AUwmk_HSrl9XxddwLf-B2W2vOzRYrHuMbfMjq1U";

        public static Stream getImage(Tuple<double, double> cor)
        {
            return RequestHelper.request(string.Format(baseUrl, key, (cor.Item2 + "," + cor.Item1)));
        }
        
    }
}
