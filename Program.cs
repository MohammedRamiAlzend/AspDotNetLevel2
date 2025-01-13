using Platform;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddHsts(opts =>
//{
//    opts.MaxAge = TimeSpan.FromDays(1);
//    opts.IncludeSubDomains = true;
//});
//builder.Services.AddSession(opts =>
//{
//    opts.IdleTimeout = TimeSpan.FromMinutes(30);
//    opts.Cookie.IsEssential = true;
//});

var app = builder.Build();

//if (app.Environment.IsProduction())
//{
//    app.UseHsts();
//}
//app.UseSession();
//app.UseMiddleware<ConsentMiddleware>();
//app.MapGet("/session", async context =>
//{
//    int counter1 = (context.Session.GetInt32("counter1") ?? 0) + 1;
//    int counter2 = (context.Session.GetInt32("counter2") ?? 0) + 1;
//    context.Session.SetInt32("counter1", counter1);
//    context.Session.SetInt32("counter2", counter2);
//    await context.Session.CommitAsync();
//    await context.Response.WriteAsync($"Counter:{counter1}, Counter2:{counter2}");
//});
//app.UseHttpsRedirection();
//app.MapFallback(async context =>
//{
//    if (context.Request.IsHttps)
//        await context.Response.WriteAsync("HTTPS!");
//    else
//        await context.Response.WriteAsync("HTTP!");
//});
app.MapGet("/",async context =>
{
    await context.Response.WriteAsync("Session 15");
});

app.Run();
