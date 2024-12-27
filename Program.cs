using Platform;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});


var app = builder.Build();

app.Use(async (context, next) =>
{
    Endpoint? end = context.GetEndpoint();
    if (end != null)
    {
        await context.Response.WriteAsync($"{end.DisplayName} Selected \n");
    }
    else
    {
        await context.Response.WriteAsync("No endpoint selected");
    }
    await next();
});


app.Map("{number:int}", async context =>
{
    await context.Response.WriteAsync("Routing to int endpoint");
}).Add(x =>
{
    ((RouteEndpointBuilder)x).Order = 0;
    x.DisplayName = "Int EndPoint";  
    });
app.Map("{number:double}", async context =>
{
    await context.Response.WriteAsync("Routing to double endpoint");
}).WithDisplayName("Double Endpoint").Add(x => ((RouteEndpointBuilder)x).Order = 1);
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
