using Platform;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(opts =>
{
    opts.IdleTimeout = TimeSpan.FromMinutes(30);
    opts.Cookie.IsEssential = true;
});
/*
builder.Services.Configure<CookiePolicyOptions>(opts =>
{
    opts.CheckConsentNeeded = context => true;
});

 */
var app = builder.Build();
app.UseSession();
app.UseMiddleware<ConsentMiddleware>();
/*
app.UseCookiePolicy(); 
app.UseMiddleware<ConsentMiddleware>();


app.MapGet("/cookie", async context =>
{
    int counter1 = int.Parse(context.Request.Cookies["counter1"] ?? "0") + 1;
    context.Response.Cookies.Append("counter1", counter1.ToString(),
        new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(30),
            IsEssential = true,
            
        });
    int counter2 = int.Parse(context.Request.Cookies["counter2"] ?? "0") + 1;
    context.Response.Cookies.Append("counter2", counter1.ToString(),
    new CookieOptions
    {
        MaxAge = TimeSpan.FromMinutes(30)
    });
    await context.Response.WriteAsync($"counter1:{counter1} , Counter2:{counter2}");
});
app.MapGet("clear", context =>
{
    context.Response.Cookies.Delete("counter1");
    context.Response.Cookies.Delete("counter2");
    context.Response.Redirect("/");
    return Task.CompletedTask;
});
 */
app.MapFallback(async context => await context.Response.WriteAsync("Hello World!"));
app.Run();
