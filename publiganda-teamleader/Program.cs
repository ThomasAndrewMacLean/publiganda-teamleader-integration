using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace publiganda_teamleader
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async System.Threading.Tasks.Task Main(string[] args)
        {

             var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            Console.WriteLine(configuration.GetSection("API_KEYS").Value.ToString());


            JObject o = JObject.FromObject(new
            {
                channel = new
                {
                    title = "James Newton-King",
                    link = "http://james.newtonking.com",
                    description = "James Newton-King's blog.",
                 
                }
            });

            // var content = new FormUrlEncodedContent(values);
            var content = new StringContent(o.ToString(), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:3000/data", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Hello World!" +  responseString);
        }
    }
}
