using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class Header
    {
        private string mime;
        private string charset;
        private string encoding;
        private string langage;
        private string httpMethodsSupported;
        private string authorizations;
        private string cache;
        private string cookie;
        private string from;
        private string host;
        private string date;
        private string userAgent;


        public Header(HttpListenerRequest request)
        {

            mime = request.Headers.Get(HttpRequestHeader.Accept.ToString());
            charset = request.Headers.Get(HttpRequestHeader.AcceptCharset.ToString());
            encoding = request.Headers.Get(HttpRequestHeader.AcceptEncoding.ToString());
            langage = request.Headers.Get(HttpRequestHeader.AcceptLanguage.ToString());
            httpMethodsSupported = request.Headers.Get(HttpRequestHeader.Allow.ToString());
            authorizations = request.Headers.Get(HttpRequestHeader.Authorization.ToString());
            cache = request.Headers.Get(HttpRequestHeader.CacheControl.ToString());
            cookie = request.Headers.Get(HttpRequestHeader.Cookie.ToString());
            from = request.Headers.Get(HttpRequestHeader.From.ToString());
            host = request.Headers.Get(HttpRequestHeader.Host.ToString());
            date = request.Headers.Get(HttpRequestHeader.Date.ToString());
            userAgent = request.Headers.Get(HttpRequestHeader.UserAgent.ToString());
        }

        public void print()
        {
            Console.WriteLine("############ Header ############");
            Console.WriteLine($"MIME : {mime}");
            Console.WriteLine($"Charset: {charset}");
            Console.WriteLine($"Encoding: {encoding}");
            Console.WriteLine($"Langage: {langage}");
            Console.WriteLine($"Methods supported: {httpMethodsSupported}");
            Console.WriteLine($"Authorizations: {authorizations}");
            Console.WriteLine($"CaheControl: {cache}");
            Console.WriteLine($"Cookie: {cookie}");
            Console.WriteLine($"From: {from}");
            Console.WriteLine($"Host: {host}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"UserAgent: {userAgent}");
            Console.WriteLine("############ Header ############");
        }

    }
}
