using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStarter.Providers
{
    public static class ApiFramework
    {
        public static async Task<string> ApiGetStringResponse(string uriString)
        {
            //Create an HTTP client object
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            Uri requestUri = new Uri(uriString);

            var jsonResponse = "";
            try
            {
                //Send the GET request
                Windows.Web.Http.HttpResponseMessage httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
            }

            return await new Task<string>(() => jsonResponse);
        }
    }
}
