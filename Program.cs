using Platform;

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
**/
/*
app.Use(async (context, next) =>
{
    await next();
    await context.Response.WriteAsync($"Status code :{context.Response.StatusCode}\n");
});
app.Use(async (context, next) =>
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
    await next();
});


app.Use(async (context, next) =>
{

    if(context.Request.Path=="/short")
    {
        await context.Response.WriteAsync($"Request short Circuited\n");
    }
    else
    {
        await next();
    }

});
//app.UseMiddleware<QueryStringMiddleware>();
*/

app.Map("/branch", branch =>
{
    //branch.UseMiddleware<QueryStringMiddleware>();
    //branch.Run(async (HttpContext context) =>
    //{
    //    await context.Response.WriteAsync($"Branch Middleware");
    //});

    branch.Run(new QueryStringMiddleware().Invoke);
});

app.MapGet("/", () => "Hello World!");

app.Run();
