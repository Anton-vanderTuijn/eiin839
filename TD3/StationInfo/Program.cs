using ContratList;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StationInfo
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
                string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v3/stations/" + args[1] + "?contract=" + args[0] + "&apiKey=" + ContratList.Program.API_KEY);

                Station s = JsonSerializer.Deserialize<Station>(responseBody);

                Console.WriteLine(s.ToStringDetails());

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
        }

    }
}
