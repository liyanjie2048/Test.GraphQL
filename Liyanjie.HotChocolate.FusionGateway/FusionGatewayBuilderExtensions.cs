namespace Microsoft.Extensions.DependencyInjection;

public static class FusionGatewayBuilderExtensions
{
    public static FusionGatewayBuilder AddEndpoint(this FusionGatewayBuilder builder,
       [DisallowNull] string name,
       [DisallowNull] Uri url)
    {
        FusionGatewayHelper.Endpoints.TryAdd(name, url);
        foreach (var item in FusionGatewayHelper.Endpoints)
        {
            builder.Services.AddHttpClient(item.Key, o => o.BaseAddress = item.Value);
        }

        return builder;
    }
}
