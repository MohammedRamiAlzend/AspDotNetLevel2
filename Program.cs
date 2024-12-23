using Platform;

using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options =>
{
    options.CityName = "Homs";

});


var app = builder.Build();
/*
    app.Map("/branch", branch =>
    {
        branch.Run(new QueryStringMiddleware().Invoke);
    });
    app.UseMiddleware<QueryStringMiddleware>();
*/
/*
app.MapGet("/location",
    async (HttpContext context, IOptions<MessageOptions> msgOpts) =>
    {
        Platform.MessageOptions opts = msgOpts.Value;
        await context.Response.WriteAsync($"{opts.CityName},{opts.CountryName}\n");
    });
*/


app.UseMiddleware<LocationMiddleware>();
app.MapGet("/", () => "Hello World!");
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
