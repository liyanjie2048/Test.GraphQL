namespace Microsoft.AspNetCore.Builder;

public static class IEndpointRouteBuilderExtensions
{
    public static IApplicationBuilder LoadFusionDoc(this IApplicationBuilder app)
    {
        FusionGatewayHelper.GetFusionDocAsync(app.ApplicationServices).ConfigureAwait(false);

        return app;
    }
}
