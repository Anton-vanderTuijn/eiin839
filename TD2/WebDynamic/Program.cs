﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace WebDynamic
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }


            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }

                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);

                // parse path in url 
                foreach (string str in request.Url.Segments)
                {
                    Console.WriteLine(str);
                }

                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);

                //parse params in url
                string val = HttpUtility.ParseQueryString(request.Url.Query).Get("val");
                string param1 = HttpUtility.ParseQueryString(request.Url.Query).Get("param1");
                string param2 = HttpUtility.ParseQueryString(request.Url.Query).Get("param2");
                string param3 = HttpUtility.ParseQueryString(request.Url.Query).Get("param3");
                string param4 = HttpUtility.ParseQueryString(request.Url.Query).Get("param4");

                Console.WriteLine("param1 = " + param1);
                Console.WriteLine("param2 = " + param2);
                Console.WriteLine("param3 = " + param3);
                Console.WriteLine("param4 = " + param4);

                //
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;


                //###############################################################

                // Construct a response.
                string responseString = null;

                Type type = typeof(MyMethods);
                try
                {
                    MethodInfo method = type.GetMethod(request.Url.Segments[3]);
                    if (method != null)
                    {
                        MyMethods c = new MyMethods();
                        object[] arguments = { };
                        if (param1 != null && param2 != null)
                        {
                            arguments = new object[] { param1, param2 };
                        } else if (val != null)
                        {
                            arguments = new object[] { val };
                        }

                        responseString = (string)method.Invoke(c, arguments);
                    } else
                    {
                        responseString = "<HTML><BODY> Hello world - Default response!</BODY></HTML>";
                    }
                }
                catch (Exception e)
                {
                    responseString = "<HTML><BODY> Hello world - Default response!</BODY></HTML>";
                }

                // Examples :
                // http://localhost:8080/q3/basic/3?param1=AAA&param2=BBB&param3=CCC
                // http://localhost:8080/q4/method/question4?param1=AAA&param2=BBB
                // http://localhost:8080/q5/exec/execQ5?param1=AAA&param2=BBB
                // http://localhost:8080/q6/bat/script?param1=AAA&param2=BBB
                // http://localhost:8080/q7/counter/increase?val=5
                // http://localhost:8080/q7/counter/decrease?val=10
                // http://localhost:8080/q7/secretnumber/guess?val=500

                //###############################################################

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                //response.AddHeader("ContentType","application/json");
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();

                Console.WriteLine("----------------------------------");
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }
}