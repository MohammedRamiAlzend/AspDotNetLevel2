namespace Platform
{
    public class WeatherEndpoint
    {
        public static async Task EndPoint(HttpContext context)
        {
            await context.Response
                .WriteAsync("Endpoint class:This is the endpoint");
        }
    }
}
