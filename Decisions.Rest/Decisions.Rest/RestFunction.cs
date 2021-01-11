using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Decisions.Rest
{
    [AutoRegisterMethodsOnClass(true, "Integration/Rest Services")]
    public class RestFunction
    {
        
        public string HttpRestRequestor(HttpMethod method, string BaseAddress, string RequestUri, KeyValuePair<string,string>[] Headers, KeyValuePair<string,string>[] Parameters)
        { 
            var client = new HttpClient();
            client.BaseAddress  = new Uri(BaseAddress);
            var req = new HttpRequestMessage(method, BaseAddress + RequestUri);
            
            foreach(var h in Headers)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(h.Key, h.Value);
               
            }
            if(Parameters != null)
            req.Content = new FormUrlEncodedContent(Parameters);
            
            var response  = client.SendAsync(req).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            return responseContent;

            
        }
    }
}
