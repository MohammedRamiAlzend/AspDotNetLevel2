namespace Platform
{
    public class Capital
    {

        public static async Task EndPoint(HttpContext context)
        {
            string? capital = null;
            string? country = context.Request.RouteValues["country"] as string;
            switch ((country??"").ToLower())
            {
                case "syria":
                    capital = "Damascus";
                    break;
                case "lebanon":
                    capital = "Beirut";
                    break;
                case "damascus":
                    //capital = "Qudus";
                    context.Response.Redirect($"/population/{country}");
                    break;
            }
            if (capital is not null)
            {
                await context.Response.WriteAsync($"{capital} is the capital op {country}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }


        /*
        private RequestDelegate? next;
        public Capital() { }
        public Capital(RequestDelegate? next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString().Split('/',
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[0] == "capital")
            {
                string? capital = null;
                string country = parts[1];
                switch (country.ToLower())
                {
                    case "syria":
                        capital = "Damascus";
                        break;
                    case "lebanon":
                        capital = "Beirut";
                        break;
                    case "damascus":
                        //capital = "Qudus";
                        context.Response.Redirect($"/population/{country}");
                        break;
                }
                if (capital is not null)
                {
                    await context.Response.WriteAsync($"{capital} is the capital op {country}");
                    return;
                }
            }
            if (next is not null)
            {
                await next(context);
            }

        }
         */
    }
}
