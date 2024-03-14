Console.Title = "Combine";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddIdentityTypes()
    .AddAccountTypes()
    .AddTypeExtension<UserExtensions>()
    .AddTypeExtension<AccountExtensions>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    .AddFluentValidation(options => options.UseFluentValidationAttribute = true)
    ;

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();

app.Run();
