using System;

namespace ExecQ5
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
                Console.WriteLine("<HTML> <BODY> Hello " + args[0] + " et " + args[1] + " Question 5 </BODY> </HTML>");
            else
                Console.WriteLine("ExeTest <string parameter>");
        }
    }
}