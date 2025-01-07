
namespace Platform.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        public async Task Format(HttpContext context, string content)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(
                $@"
                    <DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <title>
                            Response
                        </title>
                    </head>
                    <body>
                        <h2>formatted response</h2>
                    </body>
                    </html>
                ");
        }
    }
}
