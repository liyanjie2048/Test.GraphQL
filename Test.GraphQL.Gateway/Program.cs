Console.Title = "Gateway";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Stitching

builder.Services.AddHttpClient("Identity", _ => _.BaseAddress = new Uri("http://localhost:5155/graphql"));
builder.Services.AddHttpClient("Account", _ => _.BaseAddress = new Uri("http://localhost:5257/graphql"));
builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema("Identity")
    .AddRemoteSchema("Account")
    //.AddTypeExtensionsFromFile("./Extend.graphql")
    .ModifyRequestOptions(options => options.IncludeExceptionDetails = false)
    ;

#endregion

#region Fusion

//builder.Services
//    .AddFusionGatewayServer()
//    .RegisterGatewayConfiguration(serviceProvider => FusionGatewayHelper.GatewaySubject)
//    .AddEndpoint("Identity", new Uri("http://localhost:5155/graphql"))
//    .AddEndpoint("Account", new Uri("http://localhost:5257/graphql"))
//    ;

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.15975569554

app.LoadFusionDoc();

app.UseWebSockets();

app.MapGraphQL();
app.MapFusionDoc();

app.Run();
