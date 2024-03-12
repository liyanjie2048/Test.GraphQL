using FluentValidation;

using Liyanjie.HotChocolate.FluentValidation;

Console.Title = "Identity";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddGraphQLServer()
    .AddIdentityTypes()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    //.TryAddTypeInterceptor<Interceptor>()
    .AddFluentValidation()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseWebSockets();
app.MapGraphQL();

app.Run();
