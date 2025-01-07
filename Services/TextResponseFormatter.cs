
namespace Platform.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private static TextResponseFormatter? shared;
        private int responseCounter = 0;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync(
                $"Response {++responseCounter}:\n {content}");
        }

        public static TextResponseFormatter singleton
        {
            get
            {
                return shared ?? new TextResponseFormatter();
            }

        }
    }
}
