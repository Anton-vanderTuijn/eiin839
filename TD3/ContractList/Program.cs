using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContratList
{
    public class Program 
    {

        public static string API_KEY = "fca94d9baafaeed2413de067ece7c4a93da8fc69";

        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {

            if (ContratList.Program.API_KEY == "")
            {
                Console.WriteLine("\nAPI KEY not define !");
                throw new ArgumentException("API KEY not define !");
            }

            try
            {
                string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + API_KEY);

                List<Contract> contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);

                foreach (Contract c in contracts)
                {
                    Console.WriteLine(c.ToString());
                }
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
