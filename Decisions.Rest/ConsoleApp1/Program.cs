using DecisionsFramework.Data.DataTypes;
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
           
            List <SimpleKeyValuePair> kvpHeaders = new List<SimpleKeyValuePair>();
            kvpHeaders.Add(new SimpleKeyValuePair("Content-Type", "text/plain"));
            kvpHeaders.Add(new SimpleKeyValuePair("AuthKey", "1459ed78-3f8e-416c-94d4-2efefbf289f2"));

            var sut = new Decisions.Rest.RestFunction().HttpRestRequestor("Post", "http://192.168.2.10:19312", "/EngineStatus", kvpHeaders.ToArray(), null); 
        }
    }
}
