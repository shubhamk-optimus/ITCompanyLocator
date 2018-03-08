using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyLocator.DataAccessLayer
{
    public class CallAPIEntity
    {
        string responseString = null;
        /// <summary>
        /// GooglePlacesApi Calling
        /// </summary>
        /// <param name="location"></param>
        public string GetResponseFromGoogleApi(string location)
        {
            var myTask = Task.Run(async () =>
            {
                string url = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=it+companies+in+" + location + "&key=AIzaSyC_SL4Eig9Gc49GlcLl7wqWMp0KYqA6-k0";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                responseString = await response.Content.ReadAsStringAsync();
            });
            myTask.Wait();
            return responseString;
        }
    }
}
