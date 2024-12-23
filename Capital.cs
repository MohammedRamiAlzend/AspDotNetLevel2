namespace Platform;

public class Capital
{

    public static async Task EndPoint(HttpContext context)
    {
        string? capital = null;
        string? country = context.Request.RouteValues["country"] as string;
        switch ((country ?? "").ToLower())
        {
            case "syria":
                capital = "Damascus";
                break;
            case "lebanon":
                capital = "Beirut";
                break;
            case "damascus":
                //capital = "Qudus";
                LinkGenerator? generator = context.RequestServices.GetService<LinkGenerator>();
                string? url = generator?.GetPathByRouteValues(context, "population", new { city = country });
                if (url != null)
                    context.Response.Redirect(url);
                return;
        }
        if (capital is not null)
            await context.Response.WriteAsync($"{capital} is the capital op {country}");
        else
            context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
}
