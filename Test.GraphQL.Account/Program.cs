Console.Title = "Account";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer()
    .AddAccountTypes()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseWebSockets();
app.MapGraphQL();

app.Run();
