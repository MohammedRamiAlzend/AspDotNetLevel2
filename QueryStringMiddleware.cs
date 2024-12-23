using Microsoft.Extensions.Options;

namespace Platform;

public class QueryStringMiddleware
{
    private RequestDelegate? next;
    public QueryStringMiddleware(RequestDelegate nextDelegate)
    {
        next = nextDelegate;
    }
    public QueryStringMiddleware()
    {

    }
    //
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Get &&
            context.Request.Query["custom"] == "true")
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "text/plain";
            }
            await context.Response.WriteAsync("Class-Based Middleware \n");

        }
        if (next is not null)
            await next(context);
    }

}

public class LocationMiddleware
{
    public RequestDelegate next;
    public MessageOptions options;
    public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> opts)
    {
        this.next = next;
        options = opts.Value;
    }
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/location")
        {
            await context.Response.WriteAsync($"{options.CityName},{options.CountryName}");
        }
        else
        {
            await next(context);
        }
    }
}
