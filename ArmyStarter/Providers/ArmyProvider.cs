using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArmyStarter.Models;
using Newtonsoft.Json;

namespace ArmyStarter.Providers
{
    public class ArmyProvider : IArmyProvider
    {
        public async Task<IEnumerable<Army>> GetArmies()
        {
            string armiesStringResponse = await ApiFramework.ApiGetStringResponse(Constants.ArmiesController);
            IEnumerable<Army> armies = JsonConvert.DeserializeObject<IEnumerable<Army>>(armiesStringResponse);
            return armies;
        }

        public void SaveArmies(IEnumerable<Army> armies)
        {
            foreach (Army army in armies)
            {
                SaveArmy(army);
            }
        }

        private async void SaveArmy(Army army)
        {
            // Construct the HttpClient and Uri. This endpoint is for test purposes only.
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            Uri uri = new Uri(Constants.ArmiesController);

            // Construct the JSON to post.
            Windows.Web.Http.HttpStringContent content = new Windows.Web.Http.HttpStringContent(
                JsonConvert.SerializeObject(army),
                Windows.Storage.Streams.UnicodeEncoding.Utf8,
                "application/json");

            // Post the JSON and wait for a response.
            Windows.Web.Http.HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                uri,
                content);

            // Make sure the post succeeded, and write out the response.
            httpResponseMessage.EnsureSuccessStatusCode();
            var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
