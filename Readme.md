# Opentelemetry with ServiceStack instrumentation problem

This application reproduces how OpenTelemetry aspnet instrumentaiton
 doesn't work in ServiceStack 3.9.
 
## How to run
I tested this in Rider:
1. Setup iis express to run the application on http://localhost:21101 
2. Execute the http requests in TestLocal.http