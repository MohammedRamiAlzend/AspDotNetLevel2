using Platform;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options =>
{
    options.CityName = "Homs";

});


var app = builder.Build();

//app.UseMiddleware<Population>();
//app.UseMiddleware<Capital>();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("{first}/{second}/{third}", async context =>
    {
        await context.Response.WriteAsync("Request was routed\n");
        foreach (var kvp in context.Request.RouteValues)
        {
            await context.Response.WriteAsync($"{kvp.Key} : {kvp.Value}\n");
        }

    });
    endpoints.MapGet("population/{city}", Population.EndPoint);
    endpoints.MapGet("capital/{country}", Capital.EndPoint);
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware reached");
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
