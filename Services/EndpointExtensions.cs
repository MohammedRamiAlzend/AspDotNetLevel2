using System.Runtime.CompilerServices;
using System.Reflection;
namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointExtensions
    {
        public static void MapEndpoint<T>(this IEndpointRouteBuilder app,
            string path, string methodName = "Endpoint")
        {

            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new Exception("Method cannot be used");
            }
            T endPointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);
            ParameterInfo[] methodParameters = methodInfo.GetParameters();
            app.MapGet(path, context =>
            {
                T endPointInstance = ActivatorUtilities
                .CreateInstance<T>(context.RequestServices);
                return (Task)(methodInfo.Invoke(endPointInstance
                                , methodParameters.Select(p => p.ParameterType == typeof(HttpContext)
                                ? context
                                : context.RequestServices.GetService(p.ParameterType)).ToArray()
                            ))!;

            });
        }
    }
}
