using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace TracingTest
{
    
    [Route("/clear","POST")]
    public class ClearRequest
    {
        
    }

    public class ClearRequestHandler : Service
    {
        public void Post(ClearRequest request)
        {
            ServiceStackAppHost.ExportedActivities.Clear();
        }
    }
}