using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDistributedMemoryCache(
//        opts =>
//        {
//            opts.SizeLimit = 200;
//        }
//    );
builder.Services.AddDistributedSqlServerCache(opts =>
{
    opts.ConnectionString = builder.Configuration["ConnectionStrings:CacheConnection"];
    opts.SchemaName = "dbo";
    opts.TableName = "DataCache";

});
builder.Services.AddResponseCaching();
builder.Services.AddSingleton<IResponseFormatter,HtmlResponseFormatter>();

var app = builder.Build();


app.UseResponseCaching();
app.MapGet("/",async context =>
{
    await context.Response.WriteAsync("Session 15");
});
app.MapEndpoint<SumEndpoint>("sum/{count:int=100000000}");
app.Run();
