using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebIII_requests.Filtros
{
    public class LogTempoExecucaoResourceFilter : IResourceFilter
    {
        Stopwatch watch = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            watch.Stop();
            Console.WriteLine($"A ação demorou {watch.ElapsedMilliseconds} ms para ser executada.");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            watch.Start();
        }
    }
}
