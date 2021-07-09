using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;


namespace VentWPF.FanDLL
{
    internal class WebFanSelect : IFanController
    {
        public static string ZAJsonRequest(string request)
        {
            // Creates an HttpWebRequest with the specified URL.
            string uri = "http://fanselect.net:8079/FSWebService";
            var httpRequest = HttpWebRequest.Create(uri);

            // Create POST data
            var postBytes = Encoding.UTF8.GetBytes(request);

            httpRequest.Method = "POST";
            httpRequest.ContentLength = postBytes.Length;

            var httpRequestStream = httpRequest.GetRequestStream();
            httpRequestStream.Write(postBytes, 0, postBytes.Length);
            httpRequestStream.Close();

            // Sends the HttpWebRequest and waits for the response.
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            // Gets the stream associated with the response.
            Stream receiveStream = httpResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

            // Pipes the stream to a higher level stream reader with the required encoding format.
            StreamReader readStream = new StreamReader(receiveStream, encode);
            string response = readStream.ReadToEnd();

            readStream.Close();
            receiveStream.Close();
            httpResponse.Close();

            return response;
        }
        public class FSSessionId
        {
            public string SESSIONID;
        }
        public static int RNums = 0;        
        public DLLRequest RequestInfo { get; set; }
        public List<FanData> GetResponce()
        {
            string response = ZAJsonRequest(RequestInfo.ToString());
            return response[0] != '[' ? null : JsonSerializer.Deserialize(response, typeof(List<FanData>)) as List<FanData>;
        }
        public string GetResponceString()
        {
            return ZAJsonRequest(RequestInfo.ToString());
        }        


        public static string Dll_WEB()
        {
            string sRequest, sResponse, sSessionId;            
            sSessionId = "";
            sRequest = "{'cmd': 'create_session'}";
            sResponse = ZAJsonRequest(sRequest);
            if (sResponse[0] == '{')
            {                
                var oSessionId = JsonSerializer.Deserialize<FSSessionId>(sResponse);
                sSessionId = oSessionId.SESSIONID;
                return sSessionId;
            }
            return null;
        }
    }
}
