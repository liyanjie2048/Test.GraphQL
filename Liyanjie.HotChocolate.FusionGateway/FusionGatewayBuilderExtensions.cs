namespace Microsoft.Extensions.DependencyInjection;

public static class FusionGatewayBuilderExtensions
{
    public static FusionGatewayBuilder RegisterEndpoints(this FusionGatewayBuilder builder,
        Dictionary<string, Uri> endpoints)
    {
        FusionGatewayHelper.Endpoints = endpoints;
        foreach (var item in FusionGatewayHelper.Endpoints)
        {
            builder.Services.AddHttpClient(item.Key, o => o.BaseAddress = item.Value);
        }

        return builder.RegisterGatewayConfiguration(serviceProvider => FusionGatewayHelper.GatewaySubject);
    }
}
