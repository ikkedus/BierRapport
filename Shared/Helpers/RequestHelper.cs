using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Shared.Helpers

{
    public static class RequestHelper
    {
        public static Stream request(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                return response.GetResponseStream();
                
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public static string request(string url,bool bul)
        {
           
            using (Stream responseStream = request(url))
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            
        }
    }
}
