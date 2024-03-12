Console.Title = "Gateway";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

#region Stitching
//builder.Services
//.AddGraphQLServer()
//.AddRemoteSchema("Identity")
//.AddRemoteSchema("Account")
//.AddTypeExtensionsFromFile("./Stitching.graphql")
#endregion
#region Fusion
builder.Services
    .AddFusionGatewayServer()
    .RegisterEndpoints(new()
    {
        ["Identity"] = new Uri("http://localhost:5155/graphql"),
        ["Account"] = new Uri("http://localhost:5257/graphql"),
    })
    ;
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.15975569554

app.LoadFusionDoc();

app.UseWebSockets();
app.MapGraphQL();
app.MapFusionDoc();

app.Run();
