using Newtonsoft.Json.Linq;
using System;

namespace SiteApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "bzxKThZ8TWYxCyX6r5Juzh6omErxATBC";
            var data = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            var start = "48.864716,2.349014";
            var end = "45.75801,4.8000158";
            var currency = "RUB";
            var request = new GetRequest($"https://public-api.blablacar.com/api/v3/trips?from_coordinate={start}&to_coordinate={end}&locale=fr-FR&currency={currency}&start_date_local={data}&key={key}"); ; ; ; ;
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var trips = json["trips"];

            foreach (var trip in trips)
            {
                var price= trip["price"];
                var amount = price["amount"];

                Console.WriteLine($"price={amount} руб.");
            }
        }
    }
}
