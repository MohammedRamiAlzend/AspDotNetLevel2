using Platform.Services;
namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private readonly IResponseFormatter formatter;
        public WeatherMiddleware(RequestDelegate nextDelegate, IResponseFormatter formatter)
        {
            next = nextDelegate;
            this.formatter = formatter;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await context.Response.WriteAsync(
                    "Middleware class: This is a middleware comment");
            }
            else
            {
                await next(context);
            }
        }
    }
}
