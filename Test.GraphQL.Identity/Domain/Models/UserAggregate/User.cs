using Test.GraphQL.Base;

namespace Test.GraphQL.Identity.Domain.Models.UserAggregate;

public class User : AggregateRootEntity
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public bool? Sex { get; set; }
    public int? Age { get; set; }
}
