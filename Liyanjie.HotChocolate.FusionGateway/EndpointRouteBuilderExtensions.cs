namespace Microsoft.AspNetCore.Builder;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapFusionDoc(this IEndpointRouteBuilder app,
        string pattern = "/fusionDoc")
    {
        app.MapGet(pattern, async (context) =>
        {
            var schemaDoc = await FusionGatewayHelper.GetFusionDocAsync(context.RequestServices);
            await context.Response.WriteAsync(schemaDoc?.ToString() ?? "null");
            await context.Response.CompleteAsync();
        });

        return app;
    }
}
