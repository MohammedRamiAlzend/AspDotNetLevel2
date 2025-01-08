using Platform.Services;
namespace Platform
{


    public class WeatherEndpoint
    {
        private IResponseFormatter formatter;
        public WeatherEndpoint(IResponseFormatter formatter)
        {
            this.formatter = formatter;
        }
        public async Task Endpoint(HttpContext context)
        {
            //IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "Endpoint Class: Getting service from an object");
        }
    }
}
