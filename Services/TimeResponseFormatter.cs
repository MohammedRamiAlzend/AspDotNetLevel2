
namespace Platform.Services
{
    public class TimeResponseFormatter : IResponseFormatter
    {
        private readonly ITimeStamper stamper;
        public TimeResponseFormatter(ITimeStamper stamper)
        {
            this.stamper = stamper;
        }
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"{stamper.TimeStamp}:{content}");
        }
    }
}
