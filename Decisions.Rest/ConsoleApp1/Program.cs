using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<KeyValuePair<string, string>> kvpHeaders = new List<KeyValuePair<string, string>>();
            kvpHeaders.Add(new KeyValuePair<string, string>("Content-Type", "text/plain"));
            kvpHeaders.Add(new KeyValuePair<string, string>("AuthKey", "1459ed78-3f8e-416c-94d4-2efefbf289f2"));

            var sut = new Decisions.Rest.RestFunction().HttpRestRequestor(HttpMethod.Post, "http://192.168.2.10:19312", "/EngineStatus", kvpHeaders, null); 
        }
    }
}
