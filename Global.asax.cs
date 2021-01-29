using System;
using System.Web;

namespace TracingTest
{
    public partial class Application : HttpApplication  
    {
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            new ServiceStackAppHost().Init();
        }

    }
}