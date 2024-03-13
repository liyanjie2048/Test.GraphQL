Console.Title = "Identity";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddGraphQLServer()
    .AddIdentityTypes()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions()
    //.TryAddTypeInterceptor<Test.GraphQL.Identity.Interceptor>()
    .AddFluentValidation(options => options.UseFluentValidationAttribute = true)
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseWebSockets();
app.MapGraphQL();

app.Run();
