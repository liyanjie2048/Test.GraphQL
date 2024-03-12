namespace Liyanjie.HotChocolate.Fusion;

class FusionGatewayHelper
{
    public static readonly ReplaySubject<GatewayConfiguration> GatewaySubject = new();
    public static IDictionary<string, Uri>? Endpoints;

    public static async Task<DocumentNode?> GetFusionDocAsync(IServiceProvider serviceProvider)
    {
        if (Endpoints?.Count > 0)
        {
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var subgraphs = await Task.WhenAll(Endpoints.Select(async _ =>
            {
                var httpClient = httpClientFactory.CreateClient(_.Key);
                var schema = await httpClient.GetStringAsync("?sdl");

                return new SubgraphConfiguration(
                    _.Key,
                    schema,
                    string.Empty,
                    new HttpClientConfiguration(_.Value),
                    null);
            }));
            var fusionSchema = await FusionGraphComposer.ComposeAsync(subgraphs);
            var fusionDocument = Utf8GraphQLParser.Parse(SchemaFormatter.FormatAsString(fusionSchema));
            //var typeNames = FusionTypeNames.From(fusionDocument);
            //var rewriter = new SyntaxRewriter<FusionGraphConfigurationToSchemaRewriterContext>();
            //var documentNode = (DocumentNode)rewriter.Rewrite(fusionDocument, new(typeNames))!;
            GatewaySubject.OnNext(new(fusionDocument));

            return fusionDocument;
        }

        return default;
    }
}
