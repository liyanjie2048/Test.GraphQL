using Test.GraphQL.Domain.AggregateModels;

namespace Test.GraphQL.GraphQL;

public class Query
{
    public static IList<ApplicationUser> Users(int offset, int limit)
    {
        return [new()];
    }

    public static ApplicationUser User(Guid id)
    {
        return new() { Id = id };
    }
}