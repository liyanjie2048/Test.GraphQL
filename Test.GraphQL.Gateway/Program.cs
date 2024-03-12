using System.Reactive.Subjects;

using HotChocolate.Fusion;
using HotChocolate.Fusion.Composition;
using HotChocolate.Language;
using HotChocolate.Language.Visitors;
using HotChocolate.Skimmed.Serialization;

Console.Title = "Gateway";

var endpoints = new Dictionary<string, Uri>
{
    ["Identity"] = new Uri("http://localhost:5155/graphql"),
    ["Account"] = new Uri("http://localhost:5257/graphql"),
};
var gatewaySubject = new ReplaySubject<GatewayConfiguration>();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
foreach (var item in endpoints)
{
    builder.Services.AddHttpClient(item.Key, o => o.BaseAddress = item.Value);
}

builder.Services.AddRazorPages();

builder.Services
#region Stitching
    //.AddGraphQLServer()
    //.AddRemoteSchema("Identity")
    //.AddRemoteSchema("Account")
    //.AddTypeExtensionsFromFile("./Stitching.graphql")
#endregion
    .AddFusionGatewayServer()
    .RegisterGatewayConfiguration(sp => gatewaySubject)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.15975569554

await ReloadAsync(app.Services);

app.UseWebSockets();
app.MapGraphQL();

app.MapGet("/reloadDocumentNode", async (context) =>
{
    var schemaDoc = await ReloadAsync(context.RequestServices);
    await context.Response.WriteAsync(schemaDoc.ToString());
    await context.Response.CompleteAsync();
});
app.Run();

async Task<DocumentNode> ReloadAsync(IServiceProvider serviceProvider)
{
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var subgraphConfigurationTasks = endpoints.Select(async _ =>
    {
        var httpClient = httpClientFactory.CreateClient(_.Key);
        var schema = await httpClient.GetStringAsync("?sdl");

        return new SubgraphConfiguration(
            _.Key,
            schema,
            string.Empty,
            new HttpClientConfiguration(_.Value),
            null);
    });
    var subgraphConfigurations = await Task.WhenAll(subgraphConfigurationTasks);
    var fusionSchema = await FusionGraphComposer.ComposeAsync(subgraphConfigurations);
    var fusionDocument = Utf8GraphQLParser.Parse(SchemaFormatter.FormatAsString(fusionSchema));
    var typeNames = FusionTypeNames.From(fusionDocument);
    var rewriter = new SyntaxRewriter<FusionGraphConfigurationToSchemaRewriterContext>();
    var documentNode = (DocumentNode)rewriter.Rewrite(fusionDocument, new(typeNames))!;
    gatewaySubject.OnNext(new GatewayConfiguration(documentNode));
    return documentNode;
}

sealed class FusionGraphConfigurationToSchemaRewriterContext(FusionTypeNames typeNames) : ISyntaxVisitorContext
{
    public FusionTypeNames TypeNames { get; } = typeNames;
}