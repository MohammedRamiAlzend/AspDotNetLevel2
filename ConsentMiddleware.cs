using Microsoft.AspNetCore.Http.Features;

namespace Platform;

public class ConsentMiddleware
{
    private RequestDelegate next;
    public ConsentMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Path == "/consent")
        {
            ITrackingConsentFeature? consentFeature = context.Features.Get<ITrackingConsentFeature>();
            if(consentFeature is not null)
            {
                if(consentFeature.HasConsent is false)
                {
                    consentFeature.GrantConsent();
                }
                else
                {
                    consentFeature.WithdrawConsent();
                }
                await context.Response.WriteAsync(consentFeature.HasConsent ? "Consent Granted\n" : "consent withdraw\n");
            }
            else
            {
                await next(context);
            }
        
        }
    }
}
