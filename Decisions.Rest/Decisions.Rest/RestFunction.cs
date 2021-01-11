using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using DecisionsFramework.Data.DataTypes;

namespace Decisions.Rest
{
    [AutoRegisterMethodsOnClass(true, "Integration/Rest Services")]
    public class RestFunction
    {
        
        public string HttpRestRequestor(string method, string BaseAddress, string RequestUri, SimpleKeyValuePair[] Headers, SimpleKeyValuePair[] Parameters)
        { 
            if(method != "Post")
            {
                throw new NotImplementedException();
            }
           
            var client = new HttpClient();
            client.BaseAddress  = new Uri(BaseAddress);
            var _method = HttpMethod.Post;
            var req = new HttpRequestMessage(_method, BaseAddress + RequestUri);
            
            foreach(var h in Headers)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation(h.Key, h.Value);
               
            }
            if (Parameters != null)
            {
                List<KeyValuePair<string, string>> LKVP = new List<KeyValuePair<string, string>>();
                foreach (var items in Parameters)
                {
                    LKVP.Add(new KeyValuePair<string, string>(items.Key, items.Value));
                }
                req.Content = new FormUrlEncodedContent(LKVP.ToArray());
            }
            
            
            var response  = client.SendAsync(req).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            return responseContent;

            
        }
    }
}
