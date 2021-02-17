using System;
using System.Diagnostics;
using System.IO;

namespace WebDynamic
{
    class MyMethods
    {
        public string question4(string param1, string param2)
        {
            return "<HTML> <BODY> Hello " + param1 + " et " + param2 + " Question 4 </BODY> </HTML>";
        }

        public string execQ5(string param1, string param2)
        {
            //
            // Set up the process with the ProcessStartInfo class.
            // https://www.dotnetperls.com/process
            //
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"..\..\..\..\ExecQ5\bin\Debug\netcoreapp3.1\ExecQ5.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        public string script(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"..\..\..\script\script.bat";
            start.Arguments = param1 + " " + param2; // Specify arguments.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {
                //
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }


        private static int cpt = 0;
        public string increase(string val)
        {

            cpt = cpt + Int32.Parse(val);

            return "{\"val\" : " + cpt + "}";
        }

        public string decrease(string val)
        {

            cpt = cpt - Int32.Parse(val);

            return "{\"val\" : " + cpt + "}";
        }


        private static int numbertoguess = -1;
        private static int counter = 0;
        private Random rnd = new Random();
        public string guess(string val)
        {

            int valgues = Int32.Parse(val);

            if (numbertoguess == -1)
            {
                numbertoguess = rnd.Next(0, 1000);
            }
            
            
            if (numbertoguess == valgues)
            {
                numbertoguess = rnd.Next(0, 1000);
                string result = "You found the secret number! (in " + counter + " tries)";
                counter = 0;
                return result;

            } else if (numbertoguess > valgues)
            {
                counter++;
                return "More!";
            } else
            {
                counter++;
                return "Less!";
            }
        }
    }
}
