using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ContratList;

namespace NearestStation
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        private static async Task Main(string[] args)
        {
            if (ContratList.Program.API_KEY == "")
            {
                Console.WriteLine("\nAPI KEY not define !");
                throw new ArgumentException("API KEY not define !");
            }

            try
            {
                string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v3/stations?&apiKey=" + ContratList.Program.API_KEY);

                List<Station> stationList = JsonSerializer.Deserialize<List<Station>>(responseBody);

                double lat = 5.2;
                double lng = 8.8; 

                 Position mypos = new Position(lat, lng);
                Console.WriteLine(mypos.findNearestStation(stationList, mypos));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\nMissing argument !");
            }
            Console.Read();

        }
    }
}
