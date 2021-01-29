using System;
using System.Collections.Generic;
using System.Diagnostics;
using Funq;
using OpenTelemetry;
using OpenTelemetry.Trace;
using ServiceStack.Common.Web;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace TracingTest
{
    public class ServiceStackAppHost : AppHostBase
    {
        public static readonly List<Activity> ExportedActivities = new List<Activity>();
        private static TracerProvider _traceProvider;

        public ServiceStackAppHost() : base(
            "TracingTest", 
            typeof(ServiceStackAppHost).Assembly
            )
        {
        }

        public override void Configure(Container container)
        {
            SetupTracing();

            SetConfig(new EndpointHostConfig
            {
            });

        }

        private static void SetupTracing()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            _traceProvider = Sdk.CreateTracerProviderBuilder()
                .AddInMemoryExporter(ExportedActivities)
                .AddHttpClientInstrumentation()
                .AddAspNetInstrumentation()
                .Build();

        }

    }
}
