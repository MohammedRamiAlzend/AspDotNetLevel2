namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        public WeatherMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;            
        }
        public async Task Invoke(HttpContext context)
        {
             if(context.Request.Path == "/middleware/class")
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
