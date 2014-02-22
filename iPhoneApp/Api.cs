using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Newtonsoft.Json;

namespace iOS.WebServiceExample.iPhoneApp
{
    public class Api
    {
        string url;

        public Api(string apiUrl)
        {
            url = string.Format("{0}/iOS.WebServiceExample.WebAPI/api/test/", apiUrl);
        }

        /// <summary>
        /// Gets certificates from Web API
        /// </summary>
        /// <returns>List of certificates</returns>
        public async Task<List<Common.Model.Certificate>> GetCertificatesAsync()
        {
            // Create request
            var request = HttpWebRequest.Create(string.Format(@"{0}getCertificates", url));
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
                // Get response wrom Web API
                using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    // Check status
                    if (response.StatusCode != HttpStatusCode.OK)
                        Console.WriteLine(String.Format("Error fetching data. Server returned status code: {0}", response.StatusCode));

                    // Get response stream & deserialize list of certificates using Json.NET
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        return JsonConvert.DeserializeObject<List<Common.Model.Certificate>>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rest Exception: " + ex.Message);
                return null;
            }
            finally
            {
                request = null;
            }
        }

        /// <summary>
        /// Gets classes from Web API
        /// </summary>
        /// <param name="type">Type of class we are searching for</param>
        /// <returns>List of classes</returns>
        public async Task<List<Common.Model.Class>> GetClassesAsync(Common.Model.ClassType type)
        {
            // Create request
            var request = HttpWebRequest.Create(string.Format(@"{0}getClasses?type={1}", url, type));
            request.ContentType = "application/json"; // tell the API we want Json returned
            request.Method = "GET";

            try
            {
                // Get response wrom Web API
                using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    // Check status
                    if (response.StatusCode != HttpStatusCode.OK)
                        Console.WriteLine(String.Format("Error fetching data. Server returned status code: {0}", response.StatusCode));

                    // Get response stream & deserialize list of classes using Json.NET
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        return JsonConvert.DeserializeObject<List<Common.Model.Class>>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rest Exception: " + ex.Message);
                return null;
            }
            finally
            {
                request = null;
            }
        }

        /// <summary>
        /// Uploads new class
        /// </summary>
        /// <param name="newClass">Instance of the new class</param>
        /// <returns>True if successful otherwise false</returns>
        public async Task<bool> UploadNewClass(Common.Model.Class newClass)
        {
            try
            {
                // Serialize new class object to a Json string
                var json = JsonConvert.SerializeObject(newClass, Formatting.Indented);

                // Setup web client
                WebClient client = new WebClient();
                client.Encoding = Encoding.ASCII;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json"); // tell the API we want Json returned

                // Upload Json string via POST method and return bytes
                byte[] returnData = await client.UploadDataTaskAsync(string.Format(@"{0}SaveClass", url), "POST", Encoding.Default.GetBytes(json));

                // Return string data as boolean
                return Convert.ToBoolean(new System.Text.ASCIIEncoding().GetString(returnData));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rest Exception: " + ex.Message);
                return false;
            }
        }
    }
}