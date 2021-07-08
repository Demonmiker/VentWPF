using System;
using System.Net;
using System.Text;
using System.IO;
using Nancy.Json;

namespace VentWPF.FanDLL
{
    interface WebFanSelect
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
        private void DllTest1_Click(object sender, EventArgs e)
        {
            string sRequest, sResponse, sSessionId;
            //-------------------------------------------Обязательно---------------------
            // Create session:
            sSessionId = "";
            sRequest = "{'cmd': 'create_session'}";

            sResponse = ZAJsonRequest(sRequest);
            if (sResponse[0] == '{')
            {
                var serializer = new JavaScriptSerializer();
                var oSessionId = serializer.Deserialize<FSSessionId>(sResponse);
                sSessionId = oSessionId.SESSIONID;
            }
            //------------------------------------------------------------------------------
            /*
             * sRequest = "{";
            sRequest += "'sessionid': '" + sSessionId + "',";   <---------------Новая запись для Web
            sRequest += "'username': '" + UsernameEdit.Text + "',";
            sRequest += "'password': '" + PasswdEdit.Text + "',";
            sRequest += "'cmd': 'search',";
            sRequest += "'fan_size': '400',";
            sRequest += "'psf': 50,";
            sRequest += "'qv': 2500,";
            sRequest += "'current_phase': 3,";
            sRequest += "'voltage': 400,";
            sRequest += "'nominal_frequency': 50,";
            sRequest += "'search_tolerance': 10";
            sRequest += "}";
             * */
        }
    }
}
