var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
 * **/
app.Use(async (context, next) =>
{
    if(context.Request.Method == HttpMethods.Get &&
        context.Request.Query["custom"] == "true"
    )
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware \n");
    }
    await next();
});


app.MapGet("/", () => "Hello World!");

app.Run();
