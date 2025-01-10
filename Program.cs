using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

//IWebHostEnvironment env = builder.Environment;
//IConfiguration config = builder.Configuration;

//builder.Services.AddScoped<IResponseFormatter,TextResponseFormatter>();
//builder.Services.AddScoped<IResponseFormatter,HtmlResponseFormatter>();
//builder.Services.AddScoped<IResponseFormatter,GuidService>();
//    (serviceProvider =>
//{
//    string? typeName = config["services:IResponseFormatter"];
//    return (IResponseFormatter)ActivatorUtilities.CreateInstance(serviceProvider, typeName == null ? typeof(GuidService) : Type.GetType(typeName)!);
//});
//builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();

//builder.Services.AddSingleton(typeof(ICollection<>),typeof(List<>));

var app = builder.Build();

//app.UseMiddleware<WeatherMiddleware>();
//app.MapGet("single", async  context =>
//{
//    IResponseFormatter formatter = context.RequestServices
//                                          .GetRequiredService<IResponseFormatter>();
//    await formatter.Format(context,"single service");
//});

//app.MapGet("/", async context =>
//{
//    IResponseFormatter formatter = context.RequestServices
//                                          .GetServices<IResponseFormatter>().First(f => f.RichOutput);
//    await formatter.Format(context, "Multiple service");
//});
//app.MapGet("string", async context =>
//{
//    ICollection<string> collection = context.RequestServices
//                                    .GetRequiredService<ICollection<string>>();

//    collection.Add($"Request {DateTime.Now.ToLongTimeString()}");

//    foreach (string str in collection)
//    {
//        await context.Response.WriteAsync($"String: {str}\n");
//    }
//});

//app.MapGet("int", async context =>
//{
//    ICollection<int> collection = context.RequestServices
//                                    .GetRequiredService<ICollection<int>>();

//    collection.Add(collection.Count+1);

//    foreach (int val in collection)
//    {
//        await context.Response.WriteAsync($"Int: {val}\n");
//    }
//});


//app.MapGet("endpoint/class", WeatherEndpoint.EndPoint);


//app.MapEndpoint("endpoint/class");

//app.MapEndpoint<WeatherEndpoint>("endpoint/class");
//app.MapGet("endpoint/function", async (HttpContext context) =>
//{
//    IResponseFormatter formatter = context.RequestServices
//    .GetRequiredService<IResponseFormatter>();
//    await formatter.Format(context, "Endpoint Function: This is the endpoint from program");
//});


app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("New Example");
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
