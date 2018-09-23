using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Shared.Helpers

{
    public static class RequestHelper
    {
        public static object request(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
