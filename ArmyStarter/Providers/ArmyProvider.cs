﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArmyStarter.Models;
using Newtonsoft.Json;

namespace ArmyStarter.Providers
{
    public class PlanArmyProvider : IPlanArmyProvider
    {
        public async Task<IEnumerable<PlanArmy>> GetArmies()
        {
            string armiesStringResponse = await ApiFramework.ApiGetStringResponse(Constants.ArmiesController);
            IEnumerable<PlanArmy> armies = JsonConvert.DeserializeObject<IEnumerable<PlanArmy>>(armiesStringResponse);
            return armies;
        }

        public void SaveArmies(IEnumerable<PlanArmy> armies)
        {
            foreach (PlanArmy army in armies)
            {
                SaveArmy(army);
            }
        }

        private async void SaveArmy(PlanArmy army)
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
