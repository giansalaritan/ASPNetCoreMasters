using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ASPNetCoreMastersToDoList.Filters
{
    public class PerformanceFilter : Attribute, IResourceFilter
    {
        const string RequestElapsedTimeKey = "RequestElapsedTime";

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Items[RequestElapsedTimeKey] = Stopwatch.StartNew();
            Console.WriteLine(string.Format("Request started for {0}", context.HttpContext.TraceIdentifier));
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Stopwatch stopwatch = (Stopwatch)context.HttpContext.Items[RequestElapsedTimeKey];
            if (stopwatch != null)
            {
                Console.WriteLine(string.Format("Request elapsed time for {0}: {1} millisecond", context.HttpContext.TraceIdentifier, stopwatch.Elapsed.TotalMilliseconds));
            }
        }
    }
}
