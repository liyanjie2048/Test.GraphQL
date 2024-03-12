using GraphQL;

using Test.GraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddGraphQL(_ =>
{
    _.AddAutoSchema<Query>();
    _.AddSystemTextJson();
    _.AddAuthorizationRule();
    _.AddUserContextBuilder(httpContext => new UserContext(httpContext.User));
    _.AddErrorInfoProvider(options => options.ExposeExceptionDetails = true);
});
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.UseGraphQL();
app.UseGraphQLAltair();
app.UseGraphQLGraphiQL();
app.UseGraphQLPlayground();
app.UseGraphQLVoyager();
app.Run();
