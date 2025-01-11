namespace Platform
{
    public class Population
    {
        public static async Task EndPoint(HttpContext context,ILogger<Population> logger)
        {
            logger.LogDebug($"Started processing for {context.Request.Path}");
            int? pop = null;
            string? city = context.Request.RouteValues["city"] as string;
            switch ((city ?? "").ToLower())
            {
                case "damascus":
                    pop = 5_250_000;
                    break;
                case "homs":
                    pop = 3_500_000;
                    break;
                case "latakia":
                    pop = 2_900_000;
                    break;

            }
            if (pop.HasValue)
            {
                await context.Response.WriteAsync($"City: {city}, Population: {pop}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            logger.LogDebug($"end processing for {context.Request.Path}");
        }
    }
}
