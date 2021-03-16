using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSOAPclient
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ServiceCalculator.CalculatorSoapClient client = new ServiceCalculator.CalculatorSoapClient();

                Console.WriteLine(client.Add(Int32.Parse(args[0]), Int32.Parse(args[1])));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\nMissing argument !");
            }
            Console.Read();
        }
    }
}
