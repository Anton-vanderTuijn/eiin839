using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTester
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ServiceReferenceCalculator.MathsOperationsClient client = new ServiceReferenceCalculator.MathsOperationsClient();

                string method = Console.ReadLine();
                int a = Int32.Parse(Console.ReadLine());
                int b = Int32.Parse(Console.ReadLine());
                switch (method.ToLower())
                {
                    case "add":
                        Console.WriteLine(client.Add(a,b));
                        break;
                    case "multiply":
                        Console.WriteLine(client.Multiply(a, b));
                        break;
                    case "subtract":
                        Console.WriteLine(client.Subtract(a, b));
                        break;
                    case "devide":
                        Console.WriteLine(client.Devide(a, b));
                        break;
                    default:
                        Console.WriteLine("One argument is not valid !");
                        break;
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\nMissing argument !");
            }
            Console.Read();

        }
    }
}
