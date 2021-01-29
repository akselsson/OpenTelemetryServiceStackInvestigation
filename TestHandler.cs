using System.Collections.Generic;
using System.Diagnostics;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace TracingTest
{
    
    [Route("/activities","GET")]
    public class ActivitiesRequest : IReturn<ActivitiesResponse>
    {
        
    }

    public class ActivitiesResponse
    {
        public IEnumerable<Activity> Activities { get; set; }
    }

    public class ActivitiesRequestHandler : Service
    {
        public ActivitiesResponse Get(ActivitiesRequest request)
        {
            return new ActivitiesResponse(){Activities = ServiceStackAppHost.ExportedActivities};
        }
    }
}