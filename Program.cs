using Platform;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("countryName",typeof(CountryRouteConstraint));
});


var app = builder.Build();

//app.UseMiddleware<Population>();
//app.UseMiddleware<Capital>();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapGet("{first:int}/{second:bool}/{*ETC..}", async context =>
    //{
    //    await context.Response.WriteAsync("Request was routed\n");
    //    foreach (var kvp in context.Request.RouteValues)
    //    {
    //        await context.Response.WriteAsync($"{kvp.Key} : {kvp.Value}\n");
    //    }
    endpoints.MapGet("{capital}/{country:countryName}", Capital.EndPoint);

    //});
    //endpoints.MapGet("capital/{country=syria}", Capital.EndPoint);
    endpoints.MapGet("capital/{country:regex(^syria|lebanon|damascus$)}", Capital.EndPoint);
    endpoints.MapGet("size/{city?}", Population.EndPoint)
    .WithMetadata(
        new RouteNameMetadata("population")
        );
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware reached");
});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint");
});

app.Run();

/**
 * HttpContext:
    1- connection
    2- Request
    3- Request Services
    4- User
    5- Response
    6- Session
    7- Features
 * 
**/
