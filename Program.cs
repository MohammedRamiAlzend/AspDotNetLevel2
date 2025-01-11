using Platform;


var builder = WebApplication.CreateBuilder(args);

var serviceConfig = builder.Configuration;

builder.Services.Configure<MessageOptions>(serviceConfig.GetSection("Location"));

//use Environment to set up services
var servicesEnv = builder.Environment;


var app = builder.Build();


//use configuration settings to set up pipeline
var pipeLineConfig = app.Configuration;


//use Environment to set up pipeline
var pipeLineEnv = app.Environment;
app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context, IConfiguration config , IWebHostEnvironment env) =>
{
    string defaultDebug = config["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"The config setting: {defaultDebug}\n");
    await context.Response.WriteAsync($"The new Settings is: {env.EnvironmentName }");
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("New Example");
});


app.Run();


//in 52:00 session 11
//open cmd and go to platform directory
//check if dotnet-user-secrets is installed or not by typing
//dotnet tool uninstall --global dotnet-user-secrets
//then install it
//dotnet tool install --global dotnet-user-secrets --version 3.0.0-preview-18579-0056
//dotnet user-secrets init

/*
    PM> dotnet user-secrets set "WebService:Id" "MyAccount"
    Successfully saved WebService:Id = MyAccount to the secret store.
    PM> dotnet user-secrets set "WebService:key" "MySecret123$"
    Successfully saved WebService:key = MySecret123$ to the secret store.
    
    PM> dotnet user-secrets list
    WebService:key = MySecret123$
    WebService:Id = MyAccount
 
 */