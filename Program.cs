using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
//builder.Services.AddScoped<IResponseFormatter, GuidService>();
builder.Services.AddScoped<IResponseFormatter, TimeResponseFormatter>();

builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();
app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context,
        "Middleware Function: This is the middleware form program");
});

//app.MapGet("endpoint/class", WeatherEndpoint.EndPoint);


//app.MapEndpoint("endpoint/class");

app.MapEndpoint<WeatherEndpoint>("endpoint/class");
app.MapGet("endpoint/function", async (HttpContext context) =>
{
    IResponseFormatter formatter = context.RequestServices
    .GetRequiredService<IResponseFormatter>();
    await formatter.Format(context, "Endpoint Function: This is the endpoint from program");
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
