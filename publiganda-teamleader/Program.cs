using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace publiganda_teamleader
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // We load in the settings here from appsettings.json
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // The data we have to send to the API endpoint
            var formContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("api_group", configuration.GetSection("API_GROUP").Value.ToString()),
                new KeyValuePair<string, string>("api_secret", configuration.GetSection("API_SECRET").Value.ToString()),
                new KeyValuePair<string, string>("amount", "100"),
                new KeyValuePair<string, string>("pageno", "0"),
                new KeyValuePair<string, string>("searchby", "IKEA"),
            });

            // Send to the API endpoint
            var response = await client.PostAsync("https://app.teamleader.eu/api/getDeals.php", formContent);

            // Convert the response into a string
            var responseString = await response.Content.ReadAsStringAsync();

            // Parse the deals from json into C# classes
            Deal[] allDeals = JsonConvert.DeserializeObject<Deal[]>(responseString);


            // Loop over the deals
            foreach (Deal deal in allDeals)
            {
                Console.WriteLine(deal.title + ": " +  deal.total_price_excl_vat + " EUR");
            }

        }
    }
}
