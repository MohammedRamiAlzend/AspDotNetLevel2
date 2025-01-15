using System.Runtime.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Platform.Services;

namespace Platform
{
    public class SumEndpoint
    {
        public async Task Endpoint(HttpContext context, IDistributedCache cache,IResponseFormatter formatter,LinkGenerator generator)
        {
            _ = int.TryParse((string)context.Request.RouteValues["count"], out int count);

            long total = 0;
            for (int i = 0; i<= count;i++)
            {
                total += i;
            }
            string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";
            context.Response.Headers["cach-controll"] = "public, max-age=120";
            string? url = generator.GetPathByRouteValues(context, null, new { count = count });
            await formatter.Format(context
                , $"<div> ({DateTime.Now.ToLongTimeString()}) Total for {count}" +
                $"</div><div> values : {totalString}</div>" +
                $"<a href={url}> Reload<a/>");
                        

        }
    }
}
