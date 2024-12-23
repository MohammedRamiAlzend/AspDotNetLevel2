namespace Platform
{
    public class Population
    {
        private RequestDelegate? next;
        public Population()
        {

        }
        public Population(RequestDelegate? next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString().Split('/',
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[0] == "population")
            {
                string city = parts[1];
                int? pop = null;

                switch (city.ToLower())
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
                    return;
                }

            }
            if (next is not null)
            {
                await next(context);
            }
        }
    }
}
