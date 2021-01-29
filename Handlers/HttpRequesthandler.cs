using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace TracingTest.Handlers
{
    
    [Route("/http","GET")]
    public class RemoteCallingRequest : IReturn<RemoteCallingResponse>
    {
        
    }

    public class RemoteCallingResponse
    {
        public HttpStatusCode Status { get; set; }
    }

    public class RemoteCallingRequestHandler : Service
    {
        static HttpClient _client = new HttpClient();
        public RemoteCallingResponse Get(RemoteCallingRequest request)
        {
            var result = _client.GetAsync("http://example.org/").Result;
            return new RemoteCallingResponse(){Status = result.StatusCode};
        }
    }
}